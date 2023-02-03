using Interfaces;
using UnityEngine;

namespace Player
{
    public class MoveInputKeyboard : MonoBehaviour,IMovementInput
    {
        public Vector3 MoveVector3 { get; private set; }

        private void Update()
        {
            GetInput();
        }

        private void GetInput()
        {
            var horizontalValue = Input.GetAxis("Horizontal");
            var verticalValue = Input.GetAxis("Vertical");
            MoveVector3 = new Vector3(horizontalValue,0, verticalValue);
        }


    }
}