using System;
using UnityEngine;

namespace Model
{
    public abstract class Transformable
    {
        protected readonly Health Health;

        public Vector2 Position { get; protected set; }

        protected Transformable()
        {
            
        }

        protected Transformable(float maxHealth)
        {
            Health = new Health(maxHealth);
        }

        public Health GetHealth()
        {
            if (Health == null)
                throw new NullReferenceException(Config.HealthMessageException);

            return Health;
        }
    }
}