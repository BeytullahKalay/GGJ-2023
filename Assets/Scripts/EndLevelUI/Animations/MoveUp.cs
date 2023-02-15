using DG.Tweening;
using EndLevelUI.Abstract;
using UnityEngine;

namespace EndLevelUI.Animations
{
    public class MoveUp : Callable
    {
        [SerializeField] private CanvasGroup canvasGroup;
        [SerializeField] private float endValue = 0;
        [SerializeField] private float duration = 2;

        private void Awake()
        {
            Action += Move;
        }

        private void Move()
        {
            canvasGroup.transform.DOMoveY(endValue, duration).From().OnComplete(CallNextActions);
        }
    }
}