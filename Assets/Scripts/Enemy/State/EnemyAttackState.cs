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
                
                //RotateToPlayer();
                
                AttemptAttack(enemyStateManager);
            }
            else
            {
                enemyStateManager.SwitchState(enemyStateManager.MoveState);
            }
        }

        // private void RotateToPlayer(Transform unitTransform)
        // {
        //     var direction = GameManager.Instance.Player.position - unitTransform.position;
        //     direction.y = 0;
        //     unitTransform.rotation = Quaternion.Lerp(unitTransform.rotation,
        //         Quaternion.LookRotation(Vector3.forward, Vector3.up), 4 * Time.deltaTime);
        // }

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