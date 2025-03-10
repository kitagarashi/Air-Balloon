using System.Collections.Generic;
using _Project.Scripts.Gameplay.Factory;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Spawn
{
    public class ObjectPool<T> : IObjectPool<T> where T : Component, IPoolable
    {
        private readonly Queue<T> _pool = new();
        private readonly IFactory<T> _factory;

        public ObjectPool(int poolSize, IFactory<T> factory)
        {
            _factory = factory;

            for (int i = 0; i < poolSize; i++)
            {
                AddObjectToPool();
            }
        }
        public T Get()
        {
            if (_pool.Count == 0)
            {
                AddObjectToPool();
            }

            var obj = _pool.Dequeue();
            obj.gameObject.SetActive(true);
            obj.OnSpawned();
            return obj;
        }

        public void Return(T obj)
        {
            obj.OnReturned();
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
        
        private void AddObjectToPool()
        {
            var obj = _factory.Create();
            obj.gameObject.SetActive(false);
            _pool.Enqueue(obj);
        }
    }
}