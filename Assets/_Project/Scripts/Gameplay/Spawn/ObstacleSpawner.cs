using _Project.Scripts.Gameplay.Factory;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Project.Scripts.Gameplay.Spawn
{
    public sealed class ObstacleSpawner : MonoBehaviour, ISpawner
    {
        private IObjectPool<Obstacle> _pool;

        [SerializeField] private Obstacle[] _obstacles;
        [SerializeField] private Transform[] _spawnPoints;
        [SerializeField, Range(1, 100)] private int _poolSize = 10;
        [SerializeField] private float _spawnInterval = 2f;

        private void Start()
        {
            var factory = new ObstacleFactory(_obstacles, transform);
            _pool = new ObjectPool<Obstacle>(_poolSize, factory);
            
            InvokeRepeating(nameof(Spawn), _spawnInterval, _spawnInterval);
        }

        public void Spawn()
        {
            var spawnPoint = _spawnPoints[Random.Range(0, _spawnPoints.Length)];
            var obstacle = _pool.Get();
            obstacle.transform.position = spawnPoint.position;
            obstacle.Init(() => _pool.Return(obstacle));
        }
    }
}