using AbstractClasses;

namespace Player
{
    public class PlayerHealthSystem : HealthSystem
    {
        private PlayerManager _playerManager;
        private PlayerLookAt _playerLookAt;
        private PlayerAnimationController _playerAnimationController;

        public LiveState State = LiveState.Alive;

        protected override void Awake()
        {
            base.Awake();
            _playerManager = GetComponent<PlayerManager>();
            _playerLookAt = GetComponent<PlayerLookAt>();
            _playerAnimationController = GetComponent<PlayerAnimationController>();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            OnDead += _playerAnimationController.TriggerDeadAnim;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            OnDead -= _playerAnimationController.TriggerDeadAnim;
        }

        public override void Die()
        {
            base.Die();
            OnPlayerDeath();
        }

        private void OnPlayerDeath()
        {
            _playerManager.enabled = false;
            _playerLookAt.enabled = false;
            State = LiveState.Dead;
        }
    }
}
