using AbstractClasses;
using Enemy.State;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyHealthSystem : HealthSystem
    {
        public override void Die()
        {
            base.Die();
            GetComponent<EnemyAnimationController>().TriggerDeadAnim();
            GetComponent<EnemyStateManager>().enabled = false;
            GetComponent<NavMeshAgent>().Stop();
        }
    }
}
