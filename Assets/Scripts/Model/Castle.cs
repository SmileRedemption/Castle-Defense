using System;
using UnityEngine;

namespace Model
{
    public class Castle : Transformable, ITarget
    {
        private readonly float _damage;

        public new Vector2 Position { get; }
        public bool IsAlive => Health.IsAlive;

        public Castle(float damage, Vector2 position) : base(Config.CastleHealth)
        {
            _damage = damage;
            Position = position;
        }

        public void ApplyDamage(float damage)
        {
            damage -= damage / 2; 
            Health.ApplyDamage(damage);
        }
    }
}
