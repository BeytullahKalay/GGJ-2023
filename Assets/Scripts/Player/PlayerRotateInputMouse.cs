using Interfaces;
using UnityEngine;

namespace Player
{
    public class PlayerRotateInputMouse : MonoBehaviour,ILookAtInput
    {
        public Vector3 LookAtPosition { get; private set; }
        
        private void GetInput()
        {
            LookAtPosition = Input.mousePosition;
        }

        private void Update()
        {
            GetInput();
        }
    }
}
