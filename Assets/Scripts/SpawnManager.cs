using System.Collections.Generic;
using System.Linq;
using AbstractClasses;
using Enemy;
using Managers;
using UnityEngine;
using Random = UnityEngine.Random;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject minionEnemy;
    [SerializeField] private GameObject mageEnemy;
    
    [SerializeField]private int maxEnemyAmountInLevel = 3;
    
    [SerializeField]private float increaseMaxEnemyAmountInSecond = 20f;
    [SerializeField] private float timeBetweenSpawns = 2f;
    
    [SerializeField] private List<Transform> spawnPositions = new List<Transform>();

    private float _nextIncreasedTime = float.MinValue;
    
    private List<Transform> _spawnedEnemies = new List<Transform>();

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
        InvokeRepeating("SpawnEnemy",0,timeBetweenSpawns);
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
        var aliveCount = _spawnedEnemies.Count(spawnedEnemy => spawnedEnemy.GetComponent<HealthSystem>().Health > 0);
        if (aliveCount > maxEnemyAmountInLevel)  return;

        var spawnEnemy = GetEnemyToSpawn();
        Vector3 spawnPosition = spawnPositions[Random.Range(0, spawnPositions.Count)].position;
        var enemy = Instantiate(spawnEnemy, spawnPosition, Quaternion.identity);
        _spawnedEnemies.Add(enemy.transform);
    }

    private GameObject GetEnemyToSpawn()
    {
        float val = Random.value;
        GameObject spawnEnemy = val > .7f ? mageEnemy : minionEnemy;
        return spawnEnemy;
    }

    private void OnLevelComplete()
    {
        foreach (var enemy in _spawnedEnemies)
        {
            enemy.GetComponent<EnemyHealthSystem>().Die();
            Destroy(this);
        }
    }
}