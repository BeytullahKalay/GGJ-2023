using Unit;
using UnityEngine;
using UnityEngine.AI;

namespace Witch.State
{
    [RequireComponent(typeof(MinionFindOpponent))]
    [RequireComponent(typeof(WitchAttack))]
    [RequireComponent(typeof(LookAtOpponent))]
    public class WitchStateManager : MonoBehaviour
    {
        private WitchBaseState _currentState;

        public WitchIdleState IdleState = new WitchIdleState();
        public WitchAttackState AttackState = new WitchAttackState();
        public WitchMoveState MoveState = new WitchMoveState();

        public MinionAnimationController MinionAnimationController { get; private set; }
        public MinionFindOpponent MinionFindOpponent { get; private set; }
        public NavMeshAgent Agent { get; private set; }
        public WitchAttack WitchAttack { get; private set; }
        public LookAtOpponent LookAtOpponent { get; private set; }

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
            WitchAttack = GetComponent<WitchAttack>();
            MinionAnimationController = GetComponent<MinionAnimationController>();
            MinionFindOpponent = GetComponent<MinionFindOpponent>();
            LookAtOpponent = GetComponent<LookAtOpponent>();
        }

        private void Start()
        {
            _currentState = IdleState;
            _currentState.EnterState(this);
        }

        private void Update()
        {
            _currentState.UpdateState(this);
            MinionAnimationController.SetAnimatorSpeedValue(Agent.velocity.magnitude);
        }

        public void SwitchState(WitchBaseState state)
        {
            _currentState = state;
            _currentState.EnterState(this);
        }
    }
}