using System;
using UnityEngine;

namespace Model
{
    public interface ITarget 
    {
        void ApplyDamage(float damage);
        Vector2 Position { get; }
    }
}
