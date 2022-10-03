using Model;
using UnityEngine;

public class Gunfire : Transformable, IUpdateable
{
    private readonly float _speed;
    private readonly Vector2 _targetPosition;

    public new Vector2 Position { get; private set; }
    public float Damage { get; }

    public Gunfire(float maxHealth, float speed, Vector2 targetPosition, Vector2 position, float damage) : base(maxHealth)
    {
        _speed = speed;
        _targetPosition = targetPosition;
        Position = position;
        Damage = damage;
    }

    public void Update(float deltaTime)
    {
        var nextPosition = Vector2.MoveTowards(Position, _targetPosition, _speed * deltaTime);
        MoveTo(nextPosition);
    }
    
    public void MoveTo(Vector2 position) => Position = position;
}