
using Unit.State;

namespace Enemy.State
{
    public abstract class MinionBaseState
    {
        public abstract void EnterState(MinionStateManager minionStateManager);

        public abstract void UpdateState(MinionStateManager minionStateManager);
    }
}
