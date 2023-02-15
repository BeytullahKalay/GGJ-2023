namespace Witch.State
{
    public class WitchIdleState : WitchBaseState
    {
        public override void EnterState(WitchStateManager witchStateManager)
        {
            
            if (NotAliveOpponent(witchStateManager)) return;
            
            witchStateManager.SwitchState(witchStateManager.MoveState);
        }

        public override void UpdateState(WitchStateManager witchStateManager)
        {
            witchStateManager.CheckWitchIsDead();

            if (NotAliveOpponent(witchStateManager)) return;
            
            witchStateManager.SwitchState(witchStateManager.MoveState);
        }
        
        private bool NotAliveOpponent(WitchStateManager minionStateManager)
        {
            return minionStateManager.MinionFindOpponent.FindClosestOpponent() == null;
        }
    }
}
