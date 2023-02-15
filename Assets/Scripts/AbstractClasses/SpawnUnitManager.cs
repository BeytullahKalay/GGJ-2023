using System.Collections.Generic;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

namespace AbstractClasses
{
    public abstract class SpawnUnitManager : MonoSingleton<SpawnUnitManager>
    {
        [SerializeField] protected List<GameObject> spawnUnit = new List<GameObject>();

        [SerializeField] private int maxUnitAmountInLevel = 3;

        [SerializeField] private float increaseMaxUnitAmountInSecond = 20f;
        [SerializeField] private float timeBetweenSpawns = 2f;

        [SerializeField] private List<Transform> spawnPositions = new List<Transform>();

        private float _nextIncreasedTime = float.MinValue;

        public List<Transform> SpawnedUnits = new List<Transform>();

        private void OnEnable()
        {
            EventManager.SunRaised += OnLevelComplete;
        }

        private void OnDisable()
        {
            EventManager.SunRaised -= OnLevelComplete;
        }

        private void Start()
        {
            InvokeRepeating("SpawnUnit", 0, timeBetweenSpawns);
        }

        private void Update()
        {
            if (Time.time > _nextIncreasedTime)
            {
                maxUnitAmountInLevel++;
                _nextIncreasedTime = Time.time + increaseMaxUnitAmountInSecond;
            }
        }

        private void SpawnUnit()
        {
            var aliveCount = CalculateAliveUnitAmount();

            if (aliveCount > maxUnitAmountInLevel) return;

            var unitToSpawn = GetUnitToSpawn();
            var spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Count)].position;
            var unit = Instantiate(unitToSpawn, spawnPosition, Quaternion.identity);
            SpawnedUnits.Add(unit.transform);
        }

        private int CalculateAliveUnitAmount()
        {
            var aliveCount = 0;

            foreach (var spawnedUnit in SpawnedUnits)
            {
                if (spawnedUnit.TryGetComponent<HealthSystem>(out var healthSystem))
                {
                    if (healthSystem.Health <= 0) continue;
                    aliveCount++;
                }
            }

            return aliveCount;
        }

        protected virtual GameObject GetUnitToSpawn()
        {
            var unitToSpawn = spawnUnit[Random.Range(0, spawnUnit.Count)];
            return unitToSpawn;
        }

        private void OnLevelComplete()
        {
            CancelInvoke();
            Destroy(this);
        }
    }
}