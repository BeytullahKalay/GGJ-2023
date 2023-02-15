using DG.Tweening;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Managers.SpawnManagers
{
    public class SpawnHealManager : MonoBehaviour
    {
        [SerializeField] private float timeBetweenSpawns = 2f;
        [SerializeField] private GameObject spawnObject;
        [SerializeField] private float spawnRadius = 4;

        [Header("Animation Values")] 
        [SerializeField] private float jumpDuration;
        [SerializeField] private float jumpPower = 10;
        private void Start()
        {
            InvokeRepeating("SpawnHeal", 0, timeBetweenSpawns);
        }
        
        private void SpawnHeal()
        {
            Debug.Log("spawn!");
            
            var obj = Instantiate(spawnObject, transform.position, Quaternion.identity);
            obj.transform.DOJump(FindJumpPosition(), jumpPower, 1, jumpDuration).SetEase(Ease.OutCubic);
        }

        private Vector3 FindJumpPosition()
        {
            var pos = Random.insideUnitCircle.normalized * spawnRadius;
            return new Vector3(pos.x, .5f, pos.y);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, spawnRadius);
        }
    }
}
