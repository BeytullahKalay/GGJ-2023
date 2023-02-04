using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class PlayerAnimationController : MonoBehaviour
    {
        private Animator _animator;

        private const string ATTACK_ANIMATION_TRIGGER_NAME = "Attack";
        private const string ATTACK_ANIMATION_SPEED_NAME = "Speed";

        private const string ATTACK_ANIMATION_NAME = "Attack";

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }


        public void CheckAttack(KeyCode attackKey)
        {
            if (Input.GetKeyDown(attackKey) && !_animator.GetCurrentAnimatorStateInfo(0).IsName(ATTACK_ANIMATION_NAME))
            {
                TriggerAttackAnimation();
            }
        }

        public void SetAnimatorSpeedValue(float speed)
        {
            _animator.SetFloat(ATTACK_ANIMATION_SPEED_NAME, speed);
        }

        private void TriggerAttackAnimation()
        {
            _animator.SetTrigger(ATTACK_ANIMATION_TRIGGER_NAME);
        }
    }
}