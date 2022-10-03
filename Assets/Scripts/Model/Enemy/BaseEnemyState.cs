using UnityEngine;

namespace Model.Enemy
{
    public abstract class BaseEnemyState
    {
        protected readonly ITarget Target;
        protected readonly Enemy Enemy;
        
        public bool IsEnable { get; protected set; }
        
        public BaseEnemyState(ITarget target, Enemy enemy)
        {
            Target = target;
            Enemy = enemy;
        }

        public abstract void Start();
        public abstract void Stop();
        public abstract void TryMoveTo(float deltaTime);
        public abstract void TryAttack();
    }
}