using System;
using UnityEngine;

public class Castle : MonoBehaviour, ITarget, IHealthChanger
{
    private readonly float _damage = 1000;
    private readonly Health _health = new Health(1000);

    public event Action Died;
    
    private void OnEnable()
    {
        _health.Died += OnDied;
    }

    private void OnDisable()
    {
        _health.Died -= OnDied;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Enemy enemy))
        {
            Invoke(nameof(Attack), 3f);
        }
    }

    public void ApplyDamage(float damage) => _health.ApplyDamage(damage);
    public Vector3 GetPosition() => transform.position;
    private void OnDied() => Died?.Invoke();
    private void Attack(Enemy enemyTarget) => enemyTarget.ApplyDamage(_damage);
    public Health GetHealth() => _health;
}
