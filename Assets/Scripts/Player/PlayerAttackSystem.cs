using AbstractClasses;
using UnityEngine;


namespace Player
{
    public class PlayerAttackSystem : AttackSystem
    {
        [SerializeField] private float knockBackForce = 10f;
        public override void Attack()
        {
            var colliders = Physics.OverlapSphere(attackPoint.position, attackPointRadius, whatIsHitLayer);
            
            
            foreach (var col in colliders)
            {
                var healthSystem = col.GetComponent<HealthSystem>();
                healthSystem.TakeDamage?.Invoke(damage);
                healthSystem.Knockback(transform,knockBackForce);
            }
        }
    }
}