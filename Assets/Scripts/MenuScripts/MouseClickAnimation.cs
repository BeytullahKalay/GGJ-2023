using DG.Tweening;
using UnityEngine;

namespace MenuScripts
{
    public class MouseClickAnimation : MonoBehaviour
    {
        [SerializeField] private float scale = 1f;
        [SerializeField] private float duration = 1f;
        [SerializeField] private Ease ease;

        private void Start()
        {
            transform.DOScale(scale, duration).SetEase(ease).SetLoops(-1, LoopType.Restart);
        }
    }
}