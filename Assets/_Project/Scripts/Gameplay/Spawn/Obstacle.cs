using System;
using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Gameplay.Spawn
{
    public class Obstacle : MonoBehaviour, IPoolable
    {
        [field: SerializeField] public bool IsConsumable { get; private set; }

        [SerializeField] private float _speed = 10f;
        [SerializeField] private Ease _ease = Ease.Linear;
        [SerializeField] private float _lifeTime = 10f;
        [SerializeField] private Vector2 _startSize = new Vector2(0.6f, 0.6f);
        private Action _onReturned;

        public void Init(Action onReturned)
        {
            _onReturned = onReturned;
            Invoke(nameof(ReturnToPool), _lifeTime);
        }

        private void Update()
        {
            transform.Translate(Vector2.left * (_speed * Time.deltaTime));
        }

        public void OnSpawned()
        {
            transform.localScale = _startSize;
            
            transform
                .DOScale(Vector2.one, _lifeTime / 2f)
                .SetEase(_ease);
        }

        public void OnReturned()
        {
            CancelInvoke();
        }

        private void ReturnToPool()
        {
            GameManager.Instance.IncreaseScore();
            _onReturned?.Invoke();
        }
    }
}