using UnityEngine;
using DG.Tweening;

namespace _Project.Services
{
    public sealed class SlowMoService : Singleton<SlowMoService>
    {
        [SerializeField] private Ease _ease = Ease.Linear;
        private Sequence _sequence;

        public void EnterSlowMo(float duration = 1f, float strength = 0.2f)
        {
            if (_sequence != null)
                _sequence.Kill();

            _sequence = DOTween.Sequence();

            _sequence
                .Append(DOTween.To(() => Time.timeScale, ctx => Time.timeScale = ctx, strength, duration))
                .Append(DOTween.To(() => Time.timeScale, ctx => Time.timeScale = ctx, 1, 0.5f))
                .SetEase(_ease);
        }
    }
}