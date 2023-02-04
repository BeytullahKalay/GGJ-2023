using Managers;
using UnityEngine;

namespace Enemy.State
{
    public class EnemyAttackState : EnemyBaseState
    {
        public override void EnterState(EnemyStateManager enemyStateManager)
        {
            
        }

        public override void UpdateState(EnemyStateManager enemyStateManager)
        {
            

            if (Vector3.Distance(enemyStateManager.transform.position, GameManager.Instance.Player.position) <=
                enemyStateManager.AttackDistance)
            {
                Debug.Log("Attack");
                AttemptAttack(enemyStateManager);
            }
            else
            {
                enemyStateManager.SwitchState(enemyStateManager.MoveState);
            }
        }

        private void AttemptAttack(EnemyStateManager enemyStateManager)
        {
            if (Time.time >= enemyStateManager.NextAttackTime)
            {
                enemyStateManager.EnemyAnimationController.TriggerAttackAnim();
                enemyStateManager.NextAttackTime = Time.time + enemyStateManager.TimeBetweenAttacks;
            }
        }
    }
}