using Managers;
using Player;
using UnityEngine;
using UnityEngine.AI;

namespace Enemy.State
{
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(EnemyAnimationController))]
    public class EnemyStateManager : MonoBehaviour
    {
        private EnemyBaseState _currentState;

        public EnemyIdleState IdleState = new EnemyIdleState();
        public EnemyMoveState MoveState = new EnemyMoveState();
        public EnemyAttackState AttackState = new EnemyAttackState();


        
        public NavMeshAgent Agent;
        
        [Header("Attack Values")]
        [SerializeField] private float _attackDistance = .15f;
        public float TimeBetweenAttacks = 1.5f;
        public float NextAttackTime = float.MinValue;

        
        public PlayerHealthSystem PlayerHealthSystem { get; private set; }
        public EnemyAnimationController EnemyAnimationController { get; private set; }
        public float AttackDistance { get;private set; }

        private void Awake()
        {
            PlayerHealthSystem = GameManager.Instance.Player.GetComponent<PlayerHealthSystem>();
            EnemyAnimationController = GetComponent<EnemyAnimationController>();
            Agent.stoppingDistance = _attackDistance;
            AttackDistance = _attackDistance;
        }

        private void Start()
        {
            _currentState = IdleState;
            _currentState.EnterState(this);
        }

        private void Update()
        {
            _currentState.UpdateState(this);
        }

        public void SwitchState(EnemyBaseState state)
        {
            _currentState = state;
            _currentState.EnterState(this);
        }
    }
}
