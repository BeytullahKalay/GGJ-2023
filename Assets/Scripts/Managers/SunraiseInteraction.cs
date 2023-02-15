using AbstractClasses;
using Managers.SpawnManagers;
using UnityEngine;

namespace Managers
{
    public class SunraiseInteraction : MonoBehaviour
    {
        [SerializeField] private SpawnUnitEnemyManager _spawnUnitEnemyManager;
        [SerializeField] private int damage;
        [SerializeField] private float callFrequencyInOneSecond = 10;

        private float _nextCallTime = float.MaxValue;
        
        
        bool _allEnemiesNotDead = true;

        private void OnEnable()
        {
            EventManager.SunRaised += StartGiveDamageToEnemies;
        }

        private void OnDisable()
        {
            EventManager.SunRaised -= StartGiveDamageToEnemies;
        }

        private void Update()
        {
            if (Time.time >= _nextCallTime && _allEnemiesNotDead)
            {
                TakeDamageAllEnemyUnits(damage);
                _nextCallTime = Time.time + 1 / callFrequencyInOneSecond;
            }
        }

        private void TakeDamageAllEnemyUnits(int damageToGive)
        {
            Debug.Log("Here");
            _allEnemiesNotDead = false;
            foreach (var enemyUnits in _spawnUnitEnemyManager.SpawnedUnits)
            {
                if (enemyUnits.TryGetComponent<HealthSystem>(out var healthSystem))
                {
                    if(healthSystem.Health <= 0) continue;
                    healthSystem.TakeDamage?.Invoke(damageToGive);
                    _allEnemiesNotDead = true;
                }
            }

            if (!_allEnemiesNotDead)
            {
                EventManager.LevelCompleted?.Invoke();
            }
            
        }

        private void StartGiveDamageToEnemies()
        {
            _nextCallTime = Time.time;
        }
    }
}
