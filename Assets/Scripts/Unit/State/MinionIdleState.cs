using UnityEngine;

namespace Unit.State
{
    public class MinionIdleState : MinionBaseState
    {
        public override void EnterState(MinionStateManager minionStateManager)
        {
            if (NotAliveOpponent(minionStateManager)) return;

            minionStateManager.SwitchState(minionStateManager.MoveState);
        }

        public override void UpdateState(MinionStateManager minionStateManager)
        {
            minionStateManager.CheckUnitIsDead();
            
            if (NotAliveOpponent(minionStateManager)) return;

            if (IsOpponentInRange(minionStateManager))
            {
                minionStateManager.SwitchState(minionStateManager.AttackState);
            }
            else
            {
                minionStateManager.SwitchState(minionStateManager.MoveState);
            }
        }

        private bool NotAliveOpponent(MinionStateManager minionStateManager)
        {
            return minionStateManager.MinionFindOpponent.FindClosestOpponent() == null;
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