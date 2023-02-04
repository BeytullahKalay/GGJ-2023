using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float moveSpeed;

        private Rigidbody _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody>();
        }

        public void Move(Vector3 moveVector)
        {
            _rb.velocity = moveVector * moveSpeed;
        }

        public float GetSpeed(Vector3 moveVector)
        {
            return moveVector.magnitude;
        }
    }
}