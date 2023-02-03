using AbstractClasses;

namespace Player
{
    public class PlayerHealthSystem : HealthSystem
    {
        private PlayerManager _playerManager;
        private PlayerLookAt _playerLookAt;

        protected override void Awake()
        {
            base.Awake();
            _playerManager = GetComponent<PlayerManager>();
            _playerLookAt = GetComponent<PlayerLookAt>();
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
        }
    }
}
