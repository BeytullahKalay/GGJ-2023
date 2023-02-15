using DG.Tweening;
using UnityEngine;

namespace MenuScripts.Animations
{
    public class SunriseAnimation : MonoBehaviour
    {
        [SerializeField] private Transform movePositionTransform;
        [SerializeField] private float moveDuration = 2f;
        [SerializeField] private GameObject tmpTextToOpen;

        private void Start()
        {
            var mySequence = DOTween.Sequence().SetLoops(int.MaxValue, LoopType.Restart).OnStepComplete(() =>
            {
                tmpTextToOpen.gameObject.SetActive(false);
            });

            mySequence.Append(transform.DOMoveY(movePositionTransform.position.y, moveDuration).OnComplete(() =>
            {
                tmpTextToOpen.gameObject.SetActive(true);
            }));

            mySequence.AppendInterval(1);
        }
    }
}