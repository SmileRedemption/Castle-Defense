using UnityEngine;


namespace Model.Enemy
{
    public class EnemyMoving : BaseEnemyState
    {
        private readonly float _speedOfMoving;
        private readonly float _range; 

        public EnemyMoving(ITarget target, Enemy enemy, float speedOfMoving) : base(target, enemy)
        {
            _speedOfMoving = speedOfMoving;
            _range = 1.2f;
        }

        public override void Start()
        {
            IsEnable = true;
        }

        public override void Stop()
        {
            IsEnable = false;
        }

        public override void TryAttack()
        {
            
        }

        public override void TryMoveTo(float deltaTime)
        {
            if (Vector2.Distance(Enemy.Position, Target.Position) < _range)
            {
                Enemy.SwitchState<EnemyAttacking>();
                return;
            }
            var newPosition = Vector2.MoveTowards(Enemy.Position, Target.Position, _speedOfMoving * deltaTime);
            Enemy.MoveTo(newPosition);
        }
    }
}