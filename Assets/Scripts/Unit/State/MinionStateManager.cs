using Enemy.State;
using Managers;
using Player;
using UnityEngine;
using UnityEngine.AI;

namespace Unit.State
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(MinionAnimationController))]
    [RequireComponent(typeof(MinionFindOpponent))]
    public class MinionStateManager : MonoBehaviour
    {
        private MinionBaseState _currentState;

        public MinionIdleState IdleState = new MinionIdleState();
        public MinionMoveState MoveState = new MinionMoveState();
        public MinionAttackState AttackState = new MinionAttackState();

        
        public NavMeshAgent Agent;


        
        public PlayerHealthSystem PlayerHealthSystem { get; private set; }
        public MinionAnimationController MinionAnimationController { get; private set; }
        public MinionAttackSystem MinionAttackSystem { get; private set; }
        public MinionFindOpponent MinionFindOpponent { get; private set; }
        public Animator Animator { get; private set; }
        public float AttackDistance { get;private set; }

        private void Awake()
        {
            PlayerHealthSystem = GameManager.Instance.Player.GetComponent<PlayerHealthSystem>();
            MinionAnimationController = GetComponent<MinionAnimationController>();
            MinionAttackSystem = GetComponent<MinionAttackSystem>();
            MinionFindOpponent = GetComponent<MinionFindOpponent>();
            Animator = GetComponent<Animator>();
        }

        private void Start()
        {
            Agent.stoppingDistance =MinionAttackSystem.AttackDistance;
            AttackDistance = MinionAttackSystem.AttackDistance;

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
