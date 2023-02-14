using UnityEngine;
using Random = UnityEngine.Random;

namespace Witch
{
    public class WitchPositioning : MonoSingleton<WitchPositioning>
    {
        [SerializeField] private float radius = 5f;
        [SerializeField] private Transform centerTransform;

        public Vector3 RandomPointOnCircleEdge()
        {
            var vector2 = Random.insideUnitCircle.normalized * radius;
            return new Vector3(vector2.x, 0, vector2.y);
        }

        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.cyan;

            Gizmos.DrawWireSphere(centerTransform.position, radius);
        }
    }
}