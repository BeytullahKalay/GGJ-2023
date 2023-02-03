using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerAttackInputKey : MonoBehaviour,IAttackInput
    {
        [SerializeField] private KeyCode attackKey;
        public KeyCode AttackKey { get; private set; }

        private void Start()
        {
            AttackKey = attackKey;
        }
    }
}
