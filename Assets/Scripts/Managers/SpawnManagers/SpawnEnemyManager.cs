using AbstractClasses;
using UnityEngine;

namespace Managers.SpawnManagers
{
    public class SpawnEnemyManager : SpawnManager
    {
        [SerializeField] [Range(0, 1)] private float spawnMinionPercent = .8f;

        [SerializeField] private Transform enemyMinionGameObject;

        public override GameObject GetEnemyToSpawn()
        {
            var val = Random.value;
            var spawnEnemy = val > spawnMinionPercent
                ? SpawnedUnits[Random.Range(0, SpawnedUnits.Count)]
                : enemyMinionGameObject;
            return spawnEnemy.gameObject;
        }
    }
}