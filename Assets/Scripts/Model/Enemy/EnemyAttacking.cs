using System.Threading;
using UnityEngine;

namespace Model.Enemy
{
    public class EnemyAttacking : BaseEnemyState
    {
        private readonly float _damage;

        public EnemyAttacking(ITarget target, Enemy enemy, float damage) : base(target, enemy)
        {
            _damage = damage;
        }

        public override void Start()
        {
            IsEnable = true;
        }

        public override void Stop()
        {
            IsEnable = false;
        }

        public override void TryMoveTo(float deltaTime)
        {
        }

        public override void TryAttack()
        {
            if (Target == null)
            {
                Enemy.SwitchState<EnemyMoving>();
                return;
            }
            
            Enemy.Attack();
            Target.ApplyDamage(_damage);
        }
    }
}