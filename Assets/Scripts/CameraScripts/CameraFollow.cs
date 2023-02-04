using UnityEngine;

namespace CameraScripts
{
    public class CameraFollow : MonoBehaviour
    {
        [SerializeField] private Transform followTarget;

        [SerializeField] private Vector3 followOffset;

        [SerializeField] private float followLerp = 4f;

       
        private void FixedUpdate()
        {
            var desPosition = followTarget.position + followOffset;
            transform.position = Vector3.Lerp(transform.position, desPosition, followLerp * Time.deltaTime);
        }
    }
}
