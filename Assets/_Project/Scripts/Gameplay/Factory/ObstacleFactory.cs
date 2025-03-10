using _Project.Scripts.Gameplay.Spawn;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Factory
{
    public sealed class ObstacleFactory : IFactory<Obstacle>
    {
        private readonly Obstacle[] _prefabs;
        private readonly Transform _parent;

        public ObstacleFactory(Obstacle[] prefabs, Transform parent)
        {
            _prefabs = prefabs;
            _parent = parent;
        }
        
        public Obstacle Create()
        {
            var prefab = _prefabs[Random.Range(0, _prefabs.Length)];
            var instance = Object.Instantiate(prefab, _parent);

            return instance;
        }
    }
}