
using UnityEngine;

namespace Witch.State
{
    public class WitchIdleState : WitchBaseState
    {
        public override void EnterState(WitchStateManager witchStateManager)
        {
            Debug.Log("Idle enter");
            if (NotAliveOpponent(witchStateManager)) return;
            
            witchStateManager.SwitchState(witchStateManager.MoveState);
        }

        public override void UpdateState(WitchStateManager witchStateManager)
        {
            Debug.Log("Idle update");

            if (NotAliveOpponent(witchStateManager)) return;
            
            witchStateManager.SwitchState(witchStateManager.MoveState);
        }
        
        private bool NotAliveOpponent(WitchStateManager minionStateManager)
        {
            return minionStateManager.MinionFindOpponent.FindClosestOpponent() == null;
        }
    }
}
