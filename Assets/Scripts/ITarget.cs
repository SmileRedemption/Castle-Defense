using System;
using UnityEngine;

public interface ITarget 
{
    void ApplyDamage(float damage);
    Vector3 GetPosition();
    event Action Died;
}
