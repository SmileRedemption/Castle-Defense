using UnityEngine;

namespace Model.Enemy
{
    public class Golem : Enemy
    {
        public Golem(float maxHealth, ITarget currentTarget, Vector2 position) : base(maxHealth, currentTarget, position)
        {
        }
    }
}