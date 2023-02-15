using System.Collections.Generic;
using Managers;
using Unit;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AbstractClasses
{
    public abstract class SpawnManager : MonoSingleton<SpawnManager>
    {
        [SerializeField] protected List<GameObject> spawnUnit = new List<GameObject>();

        [SerializeField] private int maxEnemyAmountInLevel = 3;

        [SerializeField] private float increaseMaxEnemyAmountInSecond = 20f;
        [SerializeField] private float timeBetweenSpawns = 2f;

        [SerializeField] private List<Transform> spawnPositions = new List<Transform>();

        private float _nextIncreasedTime = float.MinValue;

        public List<Transform> SpawnedUnits = new List<Transform>();

        private void OnEnable()
        {
            EventManager.LevelCompleted += OnLevelComplete;
        }

        private void OnDisable()
        {
            EventManager.LevelCompleted -= OnLevelComplete;
        }

        private void Start()
        {
            InvokeRepeating("SpawnEnemy", 0, timeBetweenSpawns);
        }

        private void Update()
        {
            if (Time.time > _nextIncreasedTime)
            {
                maxEnemyAmountInLevel++;
                _nextIncreasedTime = Time.time + increaseMaxEnemyAmountInSecond;
            }
        }

        private void SpawnEnemy()
        {
            var aliveCount = CalculateAliveEnemyAmount();

            if (aliveCount > maxEnemyAmountInLevel) return;

            var spawnEnemy = GetUnitToSpawn();
            Vector3 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Count)].position;
            var enemy = Instantiate(spawnEnemy, spawnPosition, Quaternion.identity);
            SpawnedUnits.Add(enemy.transform);
        }

        private int CalculateAliveEnemyAmount()
        {
            var aliveCount = 0;

            foreach (var spawnedEnemy in SpawnedUnits)
            {
                if (spawnedEnemy.TryGetComponent<HealthSystem>(out var healthSystem))
                {
                    if(healthSystem.Health <= 0) continue;
                    aliveCount++;
                };
            }

            return aliveCount;
        }

        protected virtual GameObject GetUnitToSpawn()
        {
            var spawnEnemy = spawnUnit[Random.Range(0, spawnUnit.Count)];
            return spawnEnemy;
        }

        private void OnLevelComplete()
        {
            foreach (var enemy in SpawnedUnits)
            {
                enemy.GetComponent<MinionHealthSystem>().Die();
                Destroy(this);
            }
        }
    }
}