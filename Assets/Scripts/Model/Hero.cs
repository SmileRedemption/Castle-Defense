using System;
using Model.Spells;
using UnityEngine;

namespace Model
{
    public abstract class Hero : Transformable, ITarget
    { 
        public new Vector2 Position { get; }
        public bool IsAlive => Health.IsAlive;

        public event Action<float> Raged;
        public event Action RestoredHealth;
        
        protected Hero(Vector2 position) : base(Config.HeroHealth)
        {
            Position = position;
        }
        
        public void ApplyDamage(float damage)
        {
            Health.ApplyDamage(damage);
        }

        public void UseSpell(Spell spell)
        {
            spell.Accept(new SpellVisitor(this));
        }

        private void Rage(float speedUp)
        {
            Raged?.Invoke(speedUp);
        }

        private void RestoreHealth()
        {
            RestoredHealth?.Invoke();
        }

        private class SpellVisitor : ISpellVisitor
        {
            private readonly Hero _hero;
            
            public SpellVisitor(Hero hero)
            {
                _hero = hero;
            }

            public void UseSpell(HealthSpell healthSpell)
            {
                _hero.GetHealth().UseHeelSpell(healthSpell.CountOfRestoreHealth);
                _hero.RestoreHealth();
            }

            public void UseSpell(RageSpell rageSpell)
            {
                _hero.Rage(rageSpell.CountOfSpeedUp);
            }
        }
    }
}