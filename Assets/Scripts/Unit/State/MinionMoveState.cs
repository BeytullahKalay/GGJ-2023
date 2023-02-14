using UnityEngine;
using UnityEngine.AI;

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
            if (IsOpponentInRange(minionStateManager))
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
                var path = new NavMeshPath();

                minionStateManager.Agent.CalculatePath(opponentTransform.position, path);
                
                if (path.status == NavMeshPathStatus.PathComplete)
                {
                    minionStateManager.Agent.SetDestination(opponentTransform.position);
                }
                else
                {
                    var hit = new NavMeshHit();

                    // go closest point

                    if (NavMesh.SamplePosition(opponentTransform.position, out hit, 20f, NavMesh.AllAreas))
                    {
                        //Debug.Log(hit.position);
                        minionStateManager.Agent.SetDestination(hit.position);
                    }
                }
            }
            else
            {
                minionStateManager.SwitchState(minionStateManager.IdleState);
            }
        }

        private bool IsOpponentInRange(MinionStateManager minionStateManager)
        {
            var attackSystem = minionStateManager.MinionAttackSystem;
            var col = Physics.OverlapSphere(attackSystem.AttackPoint.position, attackSystem.AttackPointRadius,
                attackSystem.WhatIsHitLayer);

            return col != null;
        }
    }
}