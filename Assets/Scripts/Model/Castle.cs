using System;
using UnityEngine;

namespace Model
{
    public class Castle : Transformable, ITarget
    {
        private readonly float _damage;

        public new Vector2 Position { get; }
        public bool IsAlive => Health.IsAlive;
        public event Action TookDamage;

        public Castle(float damage, Vector2 position) : base(Config.CastleHealth)
        {
            _damage = damage;
            Position = position;
        }

        public void ApplyDamage(float damage)
        {
            const int numberOfMultiplyDamage = 10;
            
            damage *= numberOfMultiplyDamage;
            TookDamage?.Invoke();
            Health.ApplyDamage(damage);
        }
    }
}
