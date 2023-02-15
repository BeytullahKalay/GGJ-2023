using AbstractClasses;
using Unit.State;
using UnityEngine.AI;

namespace Unit
{
    public class MinionHealthSystem : HealthSystem
    {
        private MinionAnimationController _minionAnimationController;
        private MinionStateManager _minionStateManager;
        private NavMeshAgent _navMeshAgent;
        
        protected override void Awake()
        {
            base.Awake();
            
            _minionAnimationController = GetComponent<MinionAnimationController>();
            _minionStateManager = GetComponent<MinionStateManager>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
        }

        public override void Die()
        {
            base.Die();
            _minionAnimationController.TriggerDeadAnim();

            if (_minionStateManager != null)
            {
                _minionStateManager.enabled = false;
            }
            
            Destroy(_navMeshAgent);
            Destroy(this);
        }
    }
}
