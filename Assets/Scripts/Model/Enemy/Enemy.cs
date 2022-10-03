using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Model.Enemy
{
    public abstract class Enemy : Transformable, IUpdateable
    {
        private readonly BaseEnemyState[] _states;

        public ITarget CurrentTarget { get; private set; }
        public  BaseEnemyState CurrentState { get; private set; }
        public new Vector2 Position { get; private set; }

        public event Action<Vector2> Moving;
        public event Action Attacking;


        protected Enemy(float maxHealth, ITarget currentTarget, Vector2 position) : base(maxHealth)
        {
            CurrentTarget = currentTarget;
            Position = position;

            _states = new BaseEnemyState[]
            {
                new EnemyAttacking(CurrentTarget, this, Config.EnemyDamage),
                new EnemyMoving(CurrentTarget,this, Config.EnemySpeedOfMovement)
            };

            CurrentState = _states.FirstOrDefault(state => state is EnemyMoving);
        }

        public void Update(float deltaTime)
        {
            CurrentState.TryMoveTo(deltaTime);
            CurrentState.TryAttack();
        }

        public void MoveTo(Vector2 position)
        {
            Position = position;
            Moving?.Invoke(Position);
        }

        public void SwitchState<T>() where T : BaseEnemyState
        {
            CurrentState.Stop();
            CurrentState = _states.FirstOrDefault(state => state is T);
            CurrentState?.Start();
        }


        public void Attack() => Attacking?.Invoke();
        public void ApplyDamage(float damage) => Health.ApplyDamage(damage);
    }
}

