using System;
using Model.Enemy;
using UnityEngine;
using Views;

namespace Spawner
{
    [Serializable]
    public struct Wave
    {
        [SerializeField] private EnemyView _enemyView;
        [SerializeField] private float _timeDelayOfSpawn;
        [SerializeField] private int _countOfEnemy;
        
        public int CountOfSpawned { get; private set;}
        public event Action AllEnemiesSpawned;

        public float TimeDelayOfSpawn => _timeDelayOfSpawn;
        public int CountOfEnemy => _countOfEnemy;
        public EnemyView EnemyView => _enemyView;

        public void Spawn()
        {
            CountOfSpawned++;

            if (CountOfSpawned >= _countOfEnemy)
                AllEnemiesSpawned?.Invoke();
        }
    }
}