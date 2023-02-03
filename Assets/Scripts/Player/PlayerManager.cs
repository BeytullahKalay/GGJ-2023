using Interfaces;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(PlayerMovement))]
    [RequireComponent(typeof(PlayerHealthSystem))]
    public class PlayerManager : MonoBehaviour
    {
        private IMovementInput _movementInput;
        //private IAttackInput _attackInput;
        private PlayerMovement _playerMovement;
        private PlayerHealthSystem _playerHealthSystem;
        
        
        private void Awake()
        {
            _movementInput = GetComponent<IMovementInput>();
            //_attackInput = GetComponent<IAttackInput>();
            _playerMovement = GetComponent<PlayerMovement>();
            _playerHealthSystem = GetComponent<PlayerHealthSystem>();
        }

        
        private void FixedUpdate()
        {
            _playerMovement.Move(_movementInput.MoveVector3);
        }
    }
}