using System;
using Interfaces;
using UnityEngine;

namespace Managers
{
    
    public class PlayerCombatManager : MonoSingleton<PlayerCombatManager>
    {
        
        public bool CanReceiveInput;
        public bool InputReceived;

        private IAttackInput _playerAttackInputKey;
        
        public void AttemptAttack(KeyCode attackKey)
        {
            if (Input.GetKeyDown(attackKey))
            {
                InputReceived = true;
                CanReceiveInput = false;
            }
            else
            {
                return;
            }
        }

        public void InputManager()
        {
            CanReceiveInput = !CanReceiveInput;
        }
    }
}
