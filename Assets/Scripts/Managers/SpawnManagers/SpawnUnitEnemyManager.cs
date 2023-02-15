using AbstractClasses;
using UnityEngine;

namespace Managers.SpawnManagers
{
    public class SpawnUnitEnemyManager : SpawnUnitManager
    {
        [SerializeField] [Range(0, 1)] private float spawnMinionPercent = .8f;

        [SerializeField] private Transform enemyMinionGameObject;

        protected override GameObject GetUnitToSpawn()
        {
            var val = Random.value;
            var spawnEnemy = val > spawnMinionPercent
                ? spawnUnit[Random.Range(0, spawnUnit.Count)].transform
                : enemyMinionGameObject;
            return spawnEnemy.gameObject;
        }
    }
}