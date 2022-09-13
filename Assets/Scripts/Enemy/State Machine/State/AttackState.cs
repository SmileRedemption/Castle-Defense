using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
public class AttackState : EnemyState
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackDelay;

    private void Start()
    {
        StartCoroutine(Attacking());
    }
    
    private IEnumerator Attacking()
    {
        while (Target.Equals(null) == false)
        {
            Target.ApplyDamage(_damage);
            yield return new WaitForSeconds(_attackDelay);
        }
    }
}
