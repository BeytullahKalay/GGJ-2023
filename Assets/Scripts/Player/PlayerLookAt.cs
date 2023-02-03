using Interfaces;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(ILookAtInput))]
    public class PlayerLookAt : MonoBehaviour
    {
        private ILookAtInput _lookAtInput;
        
        [SerializeField] private LayerMask groundLayer;
        
        [SerializeField] private Camera _mainCam;


        private void Awake()
        {
            _lookAtInput = GetComponent<ILookAtInput>();
        }

        private Vector3 GetLookAtPosition(Vector3 inputPosition)
        {
            var ray = _mainCam.ScreenPointToRay(inputPosition);

            if (Physics.Raycast(ray, out var hitInfo,Mathf.Infinity,groundLayer))
            {
                return hitInfo.point;
            }
            else
            {
                return Vector3.zero;
            }
        }

        private void Update()
        {
            Aim();
        }

        private void Aim()
        {
            var direction = GetLookAtPosition(_lookAtInput.LookAtPosition) - transform.position;
            direction.y = 0;
            transform.forward = direction;
        }
        
    }
}
