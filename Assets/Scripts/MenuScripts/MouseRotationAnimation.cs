using UnityEngine;
using DG.Tweening;

namespace MenuScripts
{
    public class MouseRotationAnimation : MonoBehaviour
    {
        [SerializeField] private float pathDuration = 4f;
        [SerializeField] private Transform[] mousePositions;

        private Vector3[] _mousePositionVector3;


        private void Awake()
        {
            InitializeMousePosition();
        }

        private void InitializeMousePosition()
        {
            _mousePositionVector3 = new Vector3[mousePositions.Length];

            for (int i = 0; i < mousePositions.Length; i++)
            {
                _mousePositionVector3[i] = mousePositions[i].position;
            }
        }

        private void Start()
        {
            transform.position = _mousePositionVector3[0];
            transform.DOPath(_mousePositionVector3, pathDuration, PathType.CatmullRom, PathMode.TopDown2D)
                .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
        }
    }
}