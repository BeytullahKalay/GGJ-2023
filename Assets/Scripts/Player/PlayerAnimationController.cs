using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _animator;

        private const string ATTACK_ANIMATION_SPEED_NAME = "Speed";
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void SetAnimatorSpeedValue(float speed)
        {
            _animator.SetFloat(ATTACK_ANIMATION_SPEED_NAME, speed);
        }
    }
}