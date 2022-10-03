using System;


public class Health
{
    private readonly float _maxHealth;
    
    public float CurrentHealth { get; private set; }
    
    public event Action<float, float> HealthChanged;
    public event Action Died; 


    public Health(float maxHealth)
    {
        _maxHealth = maxHealth;
        CurrentHealth = maxHealth;
    }

    public void ApplyDamage(float damage)
    {
        if (damage < 0)
            throw new ArgumentException(nameof(damage));

        CurrentHealth -= damage;
        HealthChanged?.Invoke(CurrentHealth, _maxHealth);

        if (CurrentHealth <= 0)
            Died?.Invoke();
    }
}