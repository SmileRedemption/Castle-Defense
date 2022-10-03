using System;
using UnityEngine;

namespace Model
{
    public class Castle : Transformable, ITarget
    {
        private readonly float _damage;

        public new Vector2 Position { get; }

        public Castle(float maxHealth, float damage, Vector2 position) : base(maxHealth)
        {
            _damage = damage;
            Position = position;
        }

        public void ApplyDamage(float damage) => Health.ApplyDamage(damage);
    }
}
