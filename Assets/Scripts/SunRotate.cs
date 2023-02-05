using DG.Tweening;
using Managers;
using UnityEngine;

public class SunRotate : MonoBehaviour
{
    [SerializeField] private Vector3 desRotation;
    [SerializeField] private float rotateDuration;
    
    private void Start()
    {
        transform.DORotate(desRotation, rotateDuration).OnComplete(() =>
        {
            EventManager.LevelCompleted?.Invoke();
        });
    }
}
