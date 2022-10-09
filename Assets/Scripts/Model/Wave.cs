using System;
using System.Collections.Generic;
using UnityEngine;
using Views;

namespace Model
{
    [Serializable]
    public class Wave : Transformable
    {
        [SerializeField] private EnemyView[] _enemyViews;
        [SerializeField] private float _timeDelayOfSpawn;
        [SerializeField] private int _countOfEnemy;

        public int CountOfSpawned { get; private set;}
        public event Action AllEnemiesSpawned;

        public event Action<int, int> Spawned;

        public float TimeDelayOfSpawn => _timeDelayOfSpawn;
        public IEnumerable<EnemyView> EnemyViews => _enemyViews;

        public void Spawn()
        {
            CountOfSpawned++;
        
            Spawned?.Invoke(CountOfSpawned, _countOfEnemy);

            if (CountOfSpawned >= _countOfEnemy)
                AllEnemiesSpawned?.Invoke();
        
        }
    }
}