using AbstractClasses;
using UnityEngine;

namespace Player
{
    public class PlayerAttackSystem : MonoBehaviour
    {
        [SerializeField] private int damage = 25;
        [SerializeField] private Transform attackPoint;
        [SerializeField] private float attackPointRadius = 4f;
        [SerializeField] private LayerMask whatIsEnemyLayer;

        // used by animation event
        public void Attack()
        {
            var colliders = Physics.OverlapSphere(attackPoint.position, attackPointRadius, whatIsEnemyLayer);
            
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