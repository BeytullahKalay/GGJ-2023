namespace Witch.State
{
    public abstract class WitchBaseState
    {
        public abstract void EnterState(WitchStateManager witchStateManager);

        public abstract void UpdateState(WitchStateManager witchStateManager);
    }
}