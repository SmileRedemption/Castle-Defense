using System;
using Model;
using UnityEngine;

public class Gunfire : Transformable, IUpdateable
{
    private readonly float _speed;
    private readonly Vector2 _enemyPosition;
    public float Damage { get; }

    public event Action<Vector2> Moved;

    public Gunfire(Vector2 position, Vector2 enemyPosition)
    {
        Position = position;
        _enemyPosition = enemyPosition;
        
        _speed = Config.GunfireSpeed;
        Damage = Config.GunfireDamage;
    }

    public void Update(float deltaTime)
    {
        var nextPosition = Vector2.MoveTowards(Position, _enemyPosition, _speed * deltaTime);
        MoveTo(nextPosition);
    }

    private void MoveTo(Vector2 position)
    {
        Position = position;
        Moved?.Invoke(Position);
    }
}