using UnityEngine;

namespace AbstractClasses
{
    public abstract class AttackSystem : MonoBehaviour
    {
        [SerializeField] protected int damage = 25;
        [SerializeField] protected Transform attackPoint;
        [SerializeField] protected float attackPointRadius = 4f;
        [SerializeField] protected LayerMask whatIsHitLayer;

        // used by animation event
        public virtual void Attack()
        {
            var colliders = Physics.OverlapSphere(attackPoint.position, attackPointRadius, whatIsHitLayer);
            
            foreach (var col in colliders)
            {
                col.GetComponent<HealthSystem>().TakeDamage?.Invoke(damage);
            }
        }


        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;

            Gizmos.DrawWireSphere(attackPoint.position, attackPointRadius);
        }
    }
}
