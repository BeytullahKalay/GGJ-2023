using Interfaces;
using Managers;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private IMovementInput _movementInput;
        private IAttackInput _attackInput;

        private PlayerMovement _playerMovement;
        private PlayerAnimationController _playerAnimationController;
        private PlayerCombatManager _playerCombatManager;

        private void Awake()
        {
            _movementInput = GetComponent<IMovementInput>();
            _attackInput = GetComponent<IAttackInput>();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAnimationController = GetComponent<PlayerAnimationController>();
            _playerCombatManager = GetComponent<PlayerCombatManager>();
        }

        private void Update()
        {
            _playerAnimationController.SetAnimatorSpeedValue(_playerMovement.GetSpeed(_movementInput.MoveVector3));
            _playerCombatManager.AttemptAttack(_attackInput.AttackKey);
        }

        private void FixedUpdate()
        {
            _playerMovement.Move(_movementInput.MoveVector3);
        }
    }
}