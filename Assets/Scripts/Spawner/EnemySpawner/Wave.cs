using System;
using System.Collections.Generic;
using UnityEngine;
using Views;
using Random = UnityEngine.Random;

namespace Spawner
{
    [Serializable]
    public struct Wave
    {
        [SerializeField] private EnemyView[] _enemyViews;
        [SerializeField] private float _timeDelayOfSpawn;
        [SerializeField] private int _countOfEnemy;
        
        public int CountOfSpawned { get; private set;}
        public event Action AllEnemiesSpawned;

        public float TimeDelayOfSpawn => _timeDelayOfSpawn;
        public int CountOfEnemy => _countOfEnemy;
        public IEnumerable<EnemyView> EnemyViews => _enemyViews;

        public void Spawn()
        {
            CountOfSpawned++;

            if (CountOfSpawned >= _countOfEnemy)
                AllEnemiesSpawned?.Invoke();
        }
    }
}