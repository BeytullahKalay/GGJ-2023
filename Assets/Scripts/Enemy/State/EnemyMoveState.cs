using Managers;

namespace Enemy.State
{
    public class EnemyMoveState : EnemyBaseState
    {
        public override void EnterState(EnemyStateManager enemyStateManager)
        {
            enemyStateManager.Agent.SetDestination(GameManager.Instance.Player.position);
        }

        public override void UpdateState(EnemyStateManager enemyStateManager)
        {
            if (enemyStateManager.Agent.remainingDistance <= enemyStateManager.AttackDistance)
            {
                enemyStateManager.SwitchState(enemyStateManager.AttackState);
                enemyStateManager.EnemyAnimationController.SetAnimatorSpeedValue(enemyStateManager.Agent.speed);
            }
            else
            {
                enemyStateManager.Agent.SetDestination(GameManager.Instance.Player.position);
            }
        }
    }
}