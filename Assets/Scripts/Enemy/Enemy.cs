using System;
using UnityEngine;

public class Enemy : MonoBehaviour, ISpawnable, IHealthChanger
{
    [SerializeField] private int _reward;
    [SerializeField] private float _healths;

    private readonly Health _health = new Health(3);
    private ITarget _target;
    private ITarget _nextTarget;
    
    public ITarget CurrentTarget => _target;
    public event Action Died;

    private void OnEnable()
    {
        _health.Died += OnDie;
    }

    private void OnDisable()
    {
        _health.Died -= Died;
    }

    private void Update()
    {
        _healths = _health.CurrentHealth;
    }

    private void OnDie()
    {
        _target.Died -= OnTargetDied;
        Died?.Invoke();
        _health.Relive();
        SetActive(false);
    }
    
    public void Init(ITarget currentTarget, ITarget nextTarget)
    {
        if (currentTarget.Equals(null))
        {
            _target = nextTarget;
            _nextTarget = null;
            _target.Died += OnTargetDied;
            return;
        }
        
        _target = currentTarget;
        _nextTarget = nextTarget;
        _target.Died += OnTargetDied;
    }

    private void OnTargetDied()
    {
        if (_nextTarget.Equals(null))
        {
            throw new NullReferenceException("The game is over");
        }
        
        _target = _nextTarget;
    }

    public void ApplyDamage(float damage) => _health.ApplyDamage(damage);
    public void SetActive(bool isActive) => gameObject.SetActive(isActive);
    public Health GetHealth() => _health;
}