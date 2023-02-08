using UnityEngine;

namespace Unit
{
    public class MinionFindOpponent : MonoBehaviour
    {
        [SerializeField] private float detectOpponentRadius = 25f;
        [SerializeField] private LayerMask opponentLayer;

        public Transform FindClosestOpponent()
        {
            var opponents = Physics.OverlapSphere(transform.position, detectOpponentRadius, opponentLayer);
            
            if (opponents.Length == 0) return null;

            var closestOpponent = opponents[0].gameObject.transform;

            foreach (var opponent in opponents)
            {
                var isNewOpponentCloserThanClosestOpponent =
                    Vector3.Distance(opponent.gameObject.transform.position, transform.position) <
                    Vector3.Distance(closestOpponent.position, transform.position);

                if (isNewOpponentCloserThanClosestOpponent)
                {
                    closestOpponent = opponent.gameObject.transform;
                }
            }

            return closestOpponent;
        }
    }
}