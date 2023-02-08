using UnityEngine;

namespace Unit
{
    [RequireComponent(typeof(Animator))]
    public class MinionAnimationController : MonoBehaviour
    {
        private const string ANIMATOR_SPEED_NAME = "Speed";
        private const string ANIMATOR_DEAD_TRIGGER_NAME = "Dead";
        private const string ANIMATOR_ATTACK_TRIGGER_NAME = "Attack";
        
        private Animator _animator;

        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void SetAnimatorSpeedValue(float speed)
        {
            _animator.SetFloat(ANIMATOR_SPEED_NAME, speed);
        }
        
        public void TriggerDeadAnim()
        {
            _animator.SetTrigger(ANIMATOR_DEAD_TRIGGER_NAME);
        }

        public void TriggerAttackAnim()
        {
            _animator.SetTrigger(ANIMATOR_ATTACK_TRIGGER_NAME);
        }
    }
}
