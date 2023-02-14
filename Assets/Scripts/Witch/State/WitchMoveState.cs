
using UnityEngine;

namespace Witch.State
{
    public class WitchMoveState : WitchBaseState
    {
        
        public override void EnterState(WitchStateManager witchStateManager)
        {
            Debug.Log("Move enter");
            
            witchStateManager.Agent.SetDestination(WitchPositioning.Instance.RandomPointOnCircleEdge());
        }

        public override void UpdateState(WitchStateManager witchStateManager)
        {
            Debug.Log("Move update");

            if (witchStateManager.Agent.remainingDistance <= 1f)
            {
                witchStateManager.SwitchState(witchStateManager.AttackState);
            }
        }
    }
}
