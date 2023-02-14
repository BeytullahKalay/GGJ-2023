namespace Witch.State
{
    public class WitchMoveState : WitchBaseState
    {
        
        public override void EnterState(WitchStateManager witchStateManager)
        {
            witchStateManager.Agent.SetDestination(WitchPositioning.Instance.RandomPointOnCircleEdge());
        }

        public override void UpdateState(WitchStateManager witchStateManager)
        {
            if (witchStateManager.Agent.remainingDistance <= 1f)
            {
                witchStateManager.SwitchState(witchStateManager.AttackState);
            }
        }
    }
}
