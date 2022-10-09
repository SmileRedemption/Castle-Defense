using System;
using System.Collections;
using System.Collections.Generic;
using Model;
using Setup;
using UnityEngine;
using Views;
using Random = UnityEngine.Random;

namespace Spawner
{ 
    public class EnemySpawner : ObjectsPool<EnemyView>
    {
        [SerializeField] private Vector2[] _spawnPoints;
        [SerializeField] private Root _root;
        [SerializeField] private WaveBar _waveBar;
        
        private Wave[] _waves;

        private Wave _currentWave;
        private int _numberOfCurrentWave;

        private void Awake()
        {
            _root.Init();
            _waves = _root.Waves;
            _currentWave = _waves[_numberOfCurrentWave];
            Initialize(_currentWave.EnemyViews, _spawnPoints[Random.Range(0, _spawnPoints.Length)]);
        }

        private void OnEnable()
        {
            _currentWave.AllEnemiesSpawned += OnAllEnemiesSpawned;
            _waveBar.GetComponent<WaveSetup>().Init(_currentWave);
        }

        private void OnDisable()
        {
            _currentWave.AllEnemiesSpawned -= OnAllEnemiesSpawned;
        }

        private void Start()
        {
            StartCoroutine(EnemiesSpawning());
        }

        private IEnumerator EnemiesSpawning()
        {
            while (enabled)
            {
                if (_currentWave.Equals(null)) 
                    continue;
            
                yield return new WaitForSeconds(_currentWave.TimeDelayOfSpawn);
                Spawn();
            }
        }

        private void Spawn()
        {
            if (TryGetObject(out EnemyView enemyView))
            {
                SetEnemy(enemyView);
                _currentWave.Spawn();
            }
        }

        private void SetEnemy(EnemyView enemyView)
        {
            enemyView.transform.position = GetPositionOfContainer();
            enemyView.GetComponent<EnemySetup>().Init(_root.Score, _root.Wizard, _root.Archer, _root.Castle);
            enemyView.TurnOn();
        }

        private void OnAllEnemiesSpawned()
        {
            if (_numberOfCurrentWave == _waves.Length - 1)
                return;
            
            SetNextWave();
            Debug.Log($"Nest wave {_numberOfCurrentWave}");
        }

        private void SetNextWave()
        {
            _currentWave.AllEnemiesSpawned -= OnAllEnemiesSpawned;
            _waveBar.GetComponent<WaveSetup>().enabled = false;
            _currentWave = _waves[++_numberOfCurrentWave];
            _waveBar.GetComponent<WaveSetup>().Init(_currentWave);
            _currentWave.AllEnemiesSpawned += OnAllEnemiesSpawned;
        }
    }
}