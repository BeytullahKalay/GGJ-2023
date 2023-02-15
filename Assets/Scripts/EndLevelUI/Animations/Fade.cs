using DG.Tweening;
using EndLevelUI.Abstract;
using UnityEngine;

namespace EndLevelUI.Animations
{
    public class Fade : Callable
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float endValue = 0;
        [SerializeField] private float duration = 2;

        private void Awake()
        {
            Action += Fading;
        }

        private void Fading()
        {
            canvasGroup.DOFade(endValue, duration).OnComplete(CallNextActions);
        }
    }
}
