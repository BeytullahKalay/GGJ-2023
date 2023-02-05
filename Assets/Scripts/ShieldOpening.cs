using DG.Tweening;
using UnityEngine;

public class ShieldOpening : MonoBehaviour
{
    [SerializeField] private float scalingDuration = .34f;
    private Vector3 _startSize;


    private void Awake()
    {
        _startSize = transform.localScale;
    }

    private void OnEnable()
    {
        transform.localScale = Vector3.zero;

        transform.DOScale(_startSize, scalingDuration).SetEase(Ease.OutBack);
    }
}
