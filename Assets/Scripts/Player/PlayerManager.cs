using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerManager : MonoBehaviour
    {
        private IMovementInput _movementInput;
        private IAttackInput _attackInput;

        private PlayerMovement _playerMovement;
        private PlayerAnimationController _playerAnimationController;

        private void Awake()
        {
            _movementInput = GetComponent<IMovementInput>();
            _attackInput = GetComponent<IAttackInput>();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerAnimationController = GetComponent<PlayerAnimationController>();
        }

        private void Update()
        {
            _playerAnimationController.CheckAttack(_attackInput.AttackKey);
            _playerAnimationController.SetAnimatorSpeedValue(_playerMovement.GetSpeed(_movementInput.MoveVector3));
        }

        private void FixedUpdate()
        {
            _playerMovement.Move(_movementInput.MoveVector3);
        }
    }
}