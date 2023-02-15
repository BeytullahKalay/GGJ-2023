using UnityEngine;

namespace Unit.State
{
    public class MinionAttackState : MinionBaseState
    {
        public override void EnterState(MinionStateManager minionStateManager)
        {
        }

        public override void UpdateState(MinionStateManager minionStateManager)
        {
            AttemptAttack(minionStateManager);
        }

        private void AttemptAttack(MinionStateManager minionStateManager)
        {
            var attackSystem = minionStateManager.AttackSystem;
            
            var colliders = Physics.OverlapSphere(attackSystem.AttackPoint.position, attackSystem.AttackPointRadius,
                attackSystem.WhatIsHitLayer);

            if (Time.time >= minionStateManager.MinionAttackSystem.NextAttackTime && colliders.Length > 0)
            {
                minionStateManager.MinionAnimationController.TriggerAttackAnim();
                minionStateManager.MinionAttackSystem.NextAttackTime =
                    Time.time + minionStateManager.MinionAttackSystem.TimeBetweenAttacks;
            }
            else
            {
                minionStateManager.SwitchState(minionStateManager.IdleState);
            }
        }
    }
}