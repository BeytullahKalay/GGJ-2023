using System.Collections.Generic;
using AbstractClasses;
using Managers;
using Unit;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoSingleton<SpawnManager>
{
    [SerializeField] private GameObject minionEnemy;
    [SerializeField] private GameObject mageEnemy;

    [SerializeField] private int maxEnemyAmountInLevel = 3;

    [SerializeField] private float increaseMaxEnemyAmountInSecond = 20f;
    [SerializeField] private float timeBetweenSpawns = 2f;

    [SerializeField] private List<Transform> spawnPositions = new List<Transform>();

    private float _nextIncreasedTime = float.MinValue;

    public List<Transform> SpawnedEnemies = new List<Transform>();

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

        var spawnEnemy = GetEnemyToSpawn();
        Vector3 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Count)].position;
        var enemy = Instantiate(spawnEnemy, spawnPosition, Quaternion.identity);
        SpawnedEnemies.Add(enemy.transform);
    }

    private int CalculateAliveEnemyAmount()
    {
        var aliveCount = 0;

        foreach (var spawnedEnemy in SpawnedEnemies)
        {
            if (!spawnedEnemy.TryGetComponent<HealthSystem>(out var healthSystem)) continue;

            if (healthSystem != null)
                aliveCount++;
        }

        return aliveCount;
    }

    private GameObject GetEnemyToSpawn()
    {
        float val = Random.value;
        GameObject spawnEnemy = val > .7f ? mageEnemy : minionEnemy;
        return spawnEnemy;
    }

    private void OnLevelComplete()
    {
        foreach (var enemy in SpawnedEnemies)
        {
            enemy.GetComponent<MinionHealthSystem>().Die();
            Destroy(this);
        }
    }
}