using Managers;
using UnityEngine.AI;

namespace Enemy.State
{
    public class EnemyIdleState : EnemyBaseState
    {
        public override void EnterState(EnemyStateManager enemyStateManager)
        {
            if (!CheckPlayerIsAlive(enemyStateManager)) return;
            
            enemyStateManager.Agent.SetDestination(GameManager.Instance.Player.position);
            
            enemyStateManager.SwitchState(enemyStateManager.MoveState);
        }

        public override void UpdateState(EnemyStateManager enemyStateManager)
        {
            if (!CheckPlayerIsAlive(enemyStateManager)) return;
            
            
            if (enemyStateManager.Agent.remainingDistance <= enemyStateManager.AttackDistance)
            {
                enemyStateManager.SwitchState(enemyStateManager.AttackState);
            }
            else
            {
                enemyStateManager.SwitchState(enemyStateManager.MoveState);
            }
        }

        private bool CheckPlayerIsAlive(EnemyStateManager enemyStateManager)
        {
            return enemyStateManager.PlayerHealthSystem.State == LiveState.Alive;
        }


    }
}
