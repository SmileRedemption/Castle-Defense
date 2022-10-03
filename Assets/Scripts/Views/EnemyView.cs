using Spawner;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Animator))]
    public class EnemyView : View, ISpawnable
    {
        private Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        public void Move(Vector2 position)
        {
            transform.position = position;
            _animator.Play("Running");
        }

        public void Attack()
        {
            _animator.Play("Attack");
        }

        public void TurnOff()
        {
            gameObject.SetActive(false);
        }

        public void TurnOn()
        {
            gameObject.SetActive(true);
        }
    }
}