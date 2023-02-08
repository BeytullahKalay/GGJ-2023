using Enemy.State;
using UnityEngine;

namespace Unit.State
{
    public class MinionMoveState : MinionBaseState
    {
        public override void EnterState(MinionStateManager minionStateManager)
        {
            MoveToOpponent(minionStateManager);
        }

        public override void UpdateState(MinionStateManager minionStateManager)
        {
            if (minionStateManager.Agent.remainingDistance <= minionStateManager.AttackDistance)
            {
                minionStateManager.SwitchState(minionStateManager.AttackState);
            }
            else
            {
                MoveToOpponent(minionStateManager);
            }
        }

        private void MoveToOpponent(MinionStateManager minionStateManager)
        {
            var opponentTransform = minionStateManager.MinionFindOpponent.FindClosestOpponent();

            if (opponentTransform != null)
            {
                minionStateManager.AttackDistance = opponentTransform.localScale.magnitude;
                
               minionStateManager.Agent.SetDestination(opponentTransform.position);
            }
            else
            {
                minionStateManager.SwitchState(minionStateManager.IdleState);
            }
        }
    }
}