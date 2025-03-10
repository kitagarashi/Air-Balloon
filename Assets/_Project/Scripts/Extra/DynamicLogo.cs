using DG.Tweening;
using UnityEngine;

namespace _Project.Scripts.Extra
{
    public class DynamicLogo : MonoBehaviour
    {
        [SerializeField] private float swingDuration = 1f;  
        [SerializeField] private float swingAmount = 10f; 

        private void Start()
        {
            AnimateSwing();
            AnimateScaling();
        }

        private void AnimateSwing()
        {
            transform.DORotate(new Vector3(0, swingAmount, 0), swingDuration)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo); 
        }

        private void AnimateScaling()
        {
            transform.DOScale(Vector3.one * 1.1f, 1f)
                .SetEase(Ease.InOutSine)
                .SetLoops(-1, LoopType.Yoyo); 
        }

    }
}
