using System;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class MoveState : EnemyState
{
    [SerializeField] private float _speed;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        if (Target.Equals(null) == false)
        {
            transform.position = Vector2.MoveTowards(transform.position,Target.GetPosition() , _speed * Time.deltaTime);
        }
    }
}
