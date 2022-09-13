using System;
using UnityEngine;

public abstract class Hero : MonoBehaviour, ITarget, IHealthChanger
{
    [SerializeField] private Weapon _weapon;
    [SerializeField] private EnemyFinder _enemyFinder;

    private Enemy _enemyTarget;
    private readonly Health _health = new Health(100);

    public event Action Died;

    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    public void Attack()
    {
        if (_enemyTarget == null)
        {
            if (_enemyFinder.TryFindEnemy(out var enemy))
            {
                _enemyTarget = enemy;
                _weapon.Shoot(_enemyTarget);
            }
            
            return;
        }

        _weapon.Shoot(_enemyTarget);
    }

    private void OnDied()
    {
        Died?.Invoke();
        Destroy(gameObject);
    }

    public void ApplyDamage(float damage) => _health.ApplyDamage(damage);
    public Vector3 GetPosition() => transform.position;
    public Health GetHealth() => _health;
}