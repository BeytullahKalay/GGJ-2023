using UnityEngine;

namespace AbstractClasses
{
    public abstract class AttackSystem : MonoBehaviour
    {
        [SerializeField] private int damage = 25;
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackPointRadius = 4f;
        [SerializeField] private LayerMask whatIsHitLayer;

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
