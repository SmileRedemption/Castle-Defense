using System.Collections;
using System.Collections.Generic;
using Setup;
using UnityEngine;
using Views;
using Random = UnityEngine.Random;

namespace Spawner
{
    public class EnemySpawner : ObjectsPool<EnemyView>
    {
        [SerializeField] private List<Wave> _waves;
        [SerializeField] private Vector2[] _spawnPoints;
        [SerializeField] private Root _root;

        private Wave _currentWave;
        private int _numberOfCurrentWave;

        private void Awake()
        {
            _root.Init();
            SetCurrentWave(_numberOfCurrentWave);
            Initialize(_currentWave.EnemyViews, _spawnPoints[Random.Range(0, _spawnPoints.Length)]);
        }

        private void OnEnable()
        {
            _currentWave.AllEnemiesSpawned += OnAllEnemiesSpawned;
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

        private void SetCurrentWave(int indexOfWave)
        {
            _currentWave = _waves[indexOfWave];
        }
        
        private void OnAllEnemiesSpawned()
        {
            _currentWave = _waves[++_numberOfCurrentWave];
        }
    }
}