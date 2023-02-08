using Enemy.State;

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
            if (NotAliveOpponent(minionStateManager)) return;

            if (minionStateManager.Agent.remainingDistance <= minionStateManager.AttackDistance)
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
    }
}