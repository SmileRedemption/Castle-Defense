using Model;
using UnityEngine;
using Views;

namespace Presenters
{
    public class GunfirePresenter : IPresenter 
    {
        private readonly Gunfire _gunfire;
        private readonly GunfireView _gunfireView;

        public GunfirePresenter(Gunfire gunfire, GunfireView gunfireView)
        {
            _gunfire = gunfire;
            _gunfireView = gunfireView;
        }

        public void Enable()
        {
            _gunfire.Moving += OnMoving;
            _gunfireView.Collided += OnCollided;
        }

        public void Disable()
        {
            _gunfire.Moving -= OnMoving;
            _gunfireView.Collided -= OnCollided;
        }

        private void OnMoving(Vector2 position)
        {
            _gunfireView.Move(position);
        }
        
        private void OnCollided(EnemyView enemyView)
        {
            enemyView.Collide(_gunfire.Damage);
        }
    }
}