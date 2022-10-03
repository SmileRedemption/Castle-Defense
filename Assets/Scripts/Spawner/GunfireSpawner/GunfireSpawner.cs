using System;
using System.Collections;
using Setup;
using UnityEngine;
using Views;

namespace Spawner.GunfireSpawner
{
    public class GunfireSpawner : ObjectsPool<GunfireView>
    {
        [SerializeField] private GunfireView _gunfireView;
        [SerializeField] private EnemyFinder _enemyFinder;
        private void Start()
        {
            Initialize(_gunfireView, transform.position);
        }
        
        public void Shoot()
        {
            if (TryGetObject(out  GunfireView gunfire))
            {
                StartCoroutine(SetGunfire(gunfire));
            }
        }

        private IEnumerator SetGunfire(GunfireView gunfireView)
        {
            yield return new WaitUntil(() => _enemyFinder.TryFindEnemy());

            gunfireView.GetComponent<GunfireSetup>().Init(_enemyFinder.EnemyView, _gunfireView);
            _enemyFinder.EnemyView.TurnOn();
        }
        
    }
}