using System;
using UnityEngine;

public class Gunfire : MonoBehaviour, ISpawnable
{
    [SerializeField] private int _damage;
    [SerializeField] private float _speed;
    
    private Transform _enemyPosition;
    private Transform _transform;

    public int Damage => _damage;

    private void Start()
    {
        _transform = transform;
    }

    private void Update()
    {
        Move();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.ApplyDamage(_damage);
        }
        
        TurnOff();
    }

    public void Init(Transform enemyPosition)
    {
        _enemyPosition = enemyPosition;
    }

    public void SetActive(bool isActive)
    {
        gameObject.SetActive(isActive);
    }

    private void TurnOff()
    {
        SetActive(false);
    }

    public void Move()
    {
        _transform.position = Vector2.MoveTowards(_transform.position, _enemyPosition.position, _speed * Time.deltaTime);
    }
}