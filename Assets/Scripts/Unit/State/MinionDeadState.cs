using UnityEngine;

namespace Unit.State
{
    public class MinionDeadState : MinionBaseState
    {
        public override void EnterState(MinionStateManager minionStateManager)
        {
            Debug.Log(minionStateManager.transform + " is dead"); 
        }

        public override void UpdateState(MinionStateManager minionStateManager)
        {
            // do nothing
        }
    }
}