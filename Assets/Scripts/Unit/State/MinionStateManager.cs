using AbstractClasses;
using UnityEngine;
using UnityEngine.AI;

namespace Unit.State
{
    [RequireComponent(typeof(MinionAnimationController))]
    [RequireComponent(typeof(MinionFindOpponent))]
    [RequireComponent(typeof(LookAtOpponent))]
    public class MinionStateManager : MonoBehaviour
    {
        private MinionBaseState _currentState;

        public MinionIdleState IdleState = new MinionIdleState();
        public MinionMoveState MoveState = new MinionMoveState();
        public MinionAttackState AttackState = new MinionAttackState();




        public MinionAnimationController MinionAnimationController { get; private set; }
        public MinionAttackSystem MinionAttackSystem { get; private set; }
        public MinionFindOpponent MinionFindOpponent { get; private set; }
        public AttackSystem AttackSystem { get; private set; }
        public NavMeshAgent Agent { get; private set; }
        public LookAtOpponent LookAtOpponent { get; private set; }

        
        private void Awake()
        {
            
            Agent = GetComponent<NavMeshAgent>();
            AttackSystem = GetComponent<AttackSystem>();
            MinionAnimationController = GetComponent<MinionAnimationController>();
            MinionAttackSystem = GetComponent<MinionAttackSystem>();
            MinionFindOpponent = GetComponent<MinionFindOpponent>();
            LookAtOpponent = GetComponent<LookAtOpponent>();
        }

        private void Start()
        {
            Agent.stoppingDistance = MinionAttackSystem.AttackDistance;


            _currentState = IdleState;
            _currentState.EnterState(this);
        }

        private void Update()
        {
            _currentState.UpdateState(this);
            MinionAnimationController.SetAnimatorSpeedValue(Agent.velocity.magnitude);
        }

        public void SwitchState(MinionBaseState state)
        {
            _currentState = state;
            _currentState.EnterState(this);
        }
    }
}