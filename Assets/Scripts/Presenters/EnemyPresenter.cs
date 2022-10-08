using Model.Enemies;
using Model.Score;
using UnityEngine;
using Views;

namespace Presenters
{
    public class EnemyPresenter : IPresenter
    {
        private readonly Enemy _enemy;
        private readonly EnemyView _enemyView;
        private readonly Score _score;

        public EnemyPresenter(Enemy model, EnemyView view, Score score)
        {
            _enemy = model;
            _enemyView = view;
            _score = score;
        }

        public void Enable()
        {
            _enemy.GetHealth().Died += OnModelDied;
            _enemy.Moving += OnEnemyMoving;
            _enemy.Attacking += OnEnemyAttacking;
            _enemyView.Collided += OnViewCollided;
        }

        public void Disable()
        {
            _enemy.GetHealth().Died -= OnModelDied;
            _enemy.Moving -= OnEnemyMoving;
            _enemy.Attacking -= OnEnemyAttacking;
            _enemyView.Collided -= OnViewCollided;
        }
        
        private void OnModelDied()
        {
            _enemy.Relieve();
            _enemyView.TurnOff();
            _score.OnEnemyDied();
        }

        private void OnEnemyAttacking()
        {
            _enemyView.Attack();
        }
        
        private void OnEnemyMoving(Vector2 position)
        {
            _enemyView.Move(position);
        }
        
        private void OnViewCollided(float damage)
        {
            _enemy.ApplyDamage(damage);
        }
    }
}