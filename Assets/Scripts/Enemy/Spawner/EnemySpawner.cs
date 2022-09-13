using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : ObjectsPool<Enemy>
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private GameObject[] _gameObjectsTargets;

    private Wave _currentWave;
    private ITarget[] _targets;
    private int _numberOfCurrentWave = 0;
    private ITarget _nextTarget;

    private void Awake()
    {
        SetCurrentWave(_numberOfCurrentWave);
        _targets = InitTargets(_gameObjectsTargets.Length);
        _nextTarget = _targets.First(target => target is Castle);
    }

    private void Start()
    {
        Initialize(_currentWave.GetEnemies());
        StartCoroutine(EnemiesSpawning());
    }

    private void OnEnable()
    {
        _currentWave.EnemiesSpawned += OnAllEnemySpawned;
    }

    private void OnDisable()
    {
        _currentWave.EnemiesSpawned -= OnAllEnemySpawned;
    }

    private IEnumerator EnemiesSpawning()
    {
        while (enabled)
        {
            if (_currentWave.Equals(null)) 
                continue;
            
            yield return new WaitForSeconds(_currentWave.TimeDelay);
            Spawn();
        }
    }

    private void Spawn()
    {
        if (TryGetObject(out Enemy enemy))
        {
            var numberOfSpawnPoint = Random.Range(0, _spawnPoints.Length);
            SetEnemy(enemy, _spawnPoints[numberOfSpawnPoint].position);
            _currentWave.Spawn();
        }
    }
    
    private void SetEnemy(Enemy enemy, Vector3 spawnPosition)
    {
        enemy.Init(GetRandomHero(), _nextTarget);
        enemy.SetActive(true);
        enemy.transform.position = spawnPosition;
    }
    
    private ITarget GetRandomHero()
    {
        var targets = _targets.Where(target => target is Hero).ToArray();

        var indexOfRandomHero = Random.Range(0, targets.Length);
        return targets[indexOfRandomHero];
    }
    
    private void OnAllEnemySpawned()
    {
        _numberOfCurrentWave++;
        _currentWave = _waves[_numberOfCurrentWave];
        Debug.Log("Next wave");
    }

    private ITarget[] InitTargets(int countOfTargets)
    {
        var target = new ITarget[countOfTargets];

        for (int i = 0; i < target.Length; i++)
        {
            if (_gameObjectsTargets[i].TryGetComponent(out ITarget gameObjectTarget) == false)
            {
                throw new ArgumentException();
            }

            target[i] = gameObjectTarget;
        }

        return target;
    }

    private void SetCurrentWave(int indexOfWave) => _currentWave = _waves[indexOfWave];
}
