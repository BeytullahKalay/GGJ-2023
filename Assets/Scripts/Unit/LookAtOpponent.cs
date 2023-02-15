using UnityEngine;

namespace Unit
{
    public class LookAtOpponent : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 3f;

        public void LookAt(Vector3 opponentPos)
        {
            var direction = opponentPos - transform.position;
            direction.y = 0;
            transform.forward =
                Vector3.Lerp(transform.forward, direction, rotationSpeed * Time.deltaTime);
        }
    }
}