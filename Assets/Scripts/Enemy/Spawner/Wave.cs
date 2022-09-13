using System;
using UnityEngine;

[Serializable]
public struct Wave
{
    [SerializeField] private Enemy[] _enemyPrefabs;
    [SerializeField] private float _timeDelay;
    [SerializeField] private int _countOfEnemy;
    
    public int CountOfSpawned { get; private set;}
    public event Action EnemiesSpawned;

    public float TimeDelay => _timeDelay;
    public int CountOfEnemy => _countOfEnemy;
    public Enemy[] GetEnemies() => _enemyPrefabs;

    public void Spawn()
    {
        CountOfSpawned++;

        if (CountOfSpawned >= _countOfEnemy)
            EnemiesSpawned?.Invoke();
    }
}