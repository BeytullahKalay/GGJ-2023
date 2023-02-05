using AbstractClasses;
using Enemy.State;
using UnityEngine.AI;

namespace Enemy
{
    public class EnemyHealthSystem : HealthSystem
    {
        private EnemyAnimationController _enemyAnimationController;
        private EnemyStateManager _enemyStateManager;
        private NavMeshAgent _navMeshAgent;
        
        protected override void Awake()
        {
            base.Awake();
            
            _enemyAnimationController = GetComponent<EnemyAnimationController>();
            _enemyStateManager = GetComponent<EnemyStateManager>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public override void Die()
        {
            base.Die();
            _enemyAnimationController.TriggerDeadAnim();
            _enemyStateManager.enabled = false;
            _navMeshAgent.Stop(true);
            Destroy(this);
        }
    }
}
