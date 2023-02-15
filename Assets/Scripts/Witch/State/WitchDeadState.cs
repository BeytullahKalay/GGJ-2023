
using UnityEngine;

namespace Witch.State
{
    public class WitchDeadState : WitchBaseState
    {
        public override void EnterState(WitchStateManager witchStateManager)
        {
            Debug.Log(witchStateManager.transform + " is dead"); 
        }

        public override void UpdateState(WitchStateManager witchStateManager)
        {
            // do nothing
        }
    }
}
