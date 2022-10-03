using System;
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
        private int _numberOfCurrentWave = 0;

        private void Start()
        {
            SetCurrentWave(_numberOfCurrentWave);
            Initialize(_currentWave.EnemyView, _spawnPoints[Random.Range(0, _spawnPoints.Length)]);
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
           enemyView.GetComponent<EnemySetup>().Init(_root.Wizard);
           enemyView.TurnOn();
        }

        private void SetCurrentWave(int indexOfWave)
        {
            _currentWave = _waves[indexOfWave];
        }
    }
}