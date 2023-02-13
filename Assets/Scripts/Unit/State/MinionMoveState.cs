using Enemy.State;
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
                
                minionStateManager.Agent.SetDestination(opponentTransform.position);
                
                //NavMeshHit navMeshHit;

                // if (NavMesh.FindClosestEdge(opponentTransform.position, out navMeshHit, NavMesh.AllAreas))
                // {
                //     Debug.Log("Find");
                //     minionStateManager.Agent.SetDestination(opponentTransform.position);
                //     minionStateManager.Agent.SetDestination(navMeshHit.position);
                // }

                // if (NavMesh.SamplePosition(opponentTransform.position, out navMeshHit, 5f, NavMesh.AllAreas))
                // {
                //     Debug.Log("Find");
                //     minionStateManager.Agent.SetDestination(navMeshHit.position);
                // }
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