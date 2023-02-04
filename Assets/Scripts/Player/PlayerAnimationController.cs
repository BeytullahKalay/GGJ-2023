using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _animator;

        private const string ANIMATOR_SPEED_NAME = "Speed";
        private const string ANIMATOR_DEAD_TRIGGER_NAME = "Dead";
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetAnimatorSpeedValue(float speed)
        {
            _animator.SetFloat(ANIMATOR_SPEED_NAME, speed);
        }

        public void SetDeadToTrue()
        {
            _animator.SetTrigger(ANIMATOR_DEAD_TRIGGER_NAME);
        }
    }
}