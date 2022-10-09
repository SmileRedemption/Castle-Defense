using System;
using System.Linq;
using Model.Enemies.States;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Model.Enemies
{
    public abstract class Enemy : Transformable, IUpdateable
    {
        private readonly BaseEnemyState[] _states;
        private readonly BaseEnemyState _startEnemyState;
        private readonly ITarget[] _targets;
        
        public ITarget CurrentTarget { get; private set; }
        public BaseEnemyState CurrentState { get; private set; }
        public new Vector2 Position { get; private set; }

        public event Action<Vector2> Moving;
        public event Action Attacking;

        protected Enemy(ITarget[] targets, Vector2 position) : base(Config.EnemyHealth)
        {
            _targets = targets;
            Position = position;
            CurrentTarget = GetAliveTarget();

            _states = new BaseEnemyState[]
            {
                new EnemyAttacking(this, Config.EnemyDamage),
                new EnemyMoving(this, Config.EnemySpeedOfMovement)
            };

            _startEnemyState = _states.FirstOrDefault(state => state is EnemyMoving);
            CurrentState = _startEnemyState;
        }

        public void Update(float deltaTime)
        {
            if (CurrentTarget == null)
                return;
            
            CurrentState.TryMoveTo(CurrentTarget.Position, deltaTime);
            CurrentState.TryAttack(CurrentTarget);
        }

        public void MoveTo(Vector2 position)
        {
            Position = position;
            Moving?.Invoke(Position);
        }

        public void SwitchState<T>() where T : BaseEnemyState
        {
            CurrentState.Stop();
            CurrentState.TargetDied -= OnTargetDied;
            CurrentState = _states.FirstOrDefault(state => state is T);

            if (CurrentState == null)
                return;

            CurrentState.TargetDied += OnTargetDied;
            CurrentState.Start();
        }

        private ITarget GetAliveTarget()
        {
            var aliveTargets = _targets.Where(target => target is Hero && target.IsAlive).ToArray();
            return aliveTargets.Length != 0 ? aliveTargets[Random.Range(0, aliveTargets.Length)] : null;
        }

        public void Relieve()
        {
            CurrentState = _startEnemyState;
            CurrentTarget = GetAliveTarget();
            Health.Relieve();
        }

        private void OnTargetDied()
        {
            CurrentTarget = _targets.FirstOrDefault(target => target is Castle);
        }
        
        public void Attack()
        {
            Attacking?.Invoke();
        }

        public void ApplyDamage(float damage)
        {
            Health.ApplyDamage(damage);
        }
    }
}