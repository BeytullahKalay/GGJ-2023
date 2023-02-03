using UnityEngine;

namespace AbstractClasses
{
    [RequireComponent(typeof(Animator))]
    public class AnimationController : MonoBehaviour
    {
        protected Animator _animator;
        
        protected const string Speed = "Speed";
        protected const string Dead = "Dead";
        protected const string Attack = "Attack";
        

        protected virtual void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        public void PlayMoveAnimation(float moveSpeed)
        {
            _animator.SetFloat(Speed,moveSpeed);
        }


        public void PlayDeadAnimation()
        {
            _animator.SetBool(Dead,true);
        }
        

        public virtual void PlayAttackAnimation()
        {
            _animator.SetTrigger(Attack);
        }
    }
}
