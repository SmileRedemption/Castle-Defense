using System;

namespace Model
{
    public class Health
    {
        private readonly float _maxHealth;
    
        public float CurrentHealth { get; private set; }
        public bool IsAlive { get; private set; }

        public event Action<float, float> HealthChanged;
        public event Action Died;
        public event Action Relieved;
        
        public Health(float maxHealth)
        {
            _maxHealth = maxHealth;
            CurrentHealth = maxHealth;
            IsAlive = true;
        }

        public void ApplyDamage(float damage)
        {
            if (damage < 0)
                throw new ArgumentException(nameof(damage));

            CurrentHealth -= damage;
            HealthChanged?.Invoke(CurrentHealth, _maxHealth);

            if (CurrentHealth <= 0)
            {
                IsAlive = false;
                Died?.Invoke();
            }
        }
        
        public void Relieve()
        {
            Relieved?.Invoke();
            CurrentHealth = _maxHealth;
            IsAlive = true;
        }

        public void UseHeelSpell(float health)
        {
            if (CurrentHealth + health > _maxHealth)
                CurrentHealth = _maxHealth;
            else
                CurrentHealth += health;
            
            HealthChanged?.Invoke(CurrentHealth, _maxHealth);
        }
    }
}