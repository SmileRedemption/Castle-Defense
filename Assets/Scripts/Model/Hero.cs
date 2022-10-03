using System;
using UnityEngine;

namespace Model
{
    public abstract class Hero : Transformable, ITarget
    { 
        public new Vector2 Position { get; }

        public Hero(float maxHealth, Vector2 position) : base(maxHealth)
        {
            Position = position;
        }

        public void ApplyDamage(float damage) => Health.ApplyDamage(damage);
    }
}