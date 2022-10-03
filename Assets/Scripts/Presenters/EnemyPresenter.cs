using System;
using Model;
using Model.Enemy;
using UnityEngine;
using Views;

namespace Presenters
{
    public class EnemyPresenter : IPresenter
    {
        private readonly Enemy _enemy;
        private readonly EnemyView _enemyView;
        
        public EnemyPresenter(Enemy model, EnemyView view)
        {
            _enemy = model;
            _enemyView = view;
        }

        public void Enable()
        {
            _enemy.GetHealth().Died += OnModelDied;
            _enemy.Moving += OnEnemyMoving;
            _enemy.Attacking += OnEnemyAttacking;
        }

        public void Disable()
        {
            _enemy.GetHealth().Died -= OnModelDied;
            _enemy.Moving -= OnEnemyMoving;
            _enemy.Attacking -= OnEnemyAttacking;
        }
        
        public void OnModelDied()
        {
            _enemyView.Died();
        }

        private void OnEnemyAttacking()
        {
            _enemyView.Attack();
        }
        
        private void OnEnemyMoving(Vector2 position)
        {
            _enemyView.Move(position);
        }
    }
}