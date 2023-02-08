using Enemy.State;
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
            if (Time.time >= minionStateManager.MinionAttackSystem.NextAttackTime)
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