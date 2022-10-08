using System;
using Spawner;
using UnityEngine;

namespace Views
{
    [RequireComponent(typeof(Animator))]
    public class EnemyView : View, ISpawnable
    {
        private Animator _animator;
        private Transform _transform;

        public event Action<float> Collided;
        
        private void Awake()
        {
            _animator = GetComponent<Animator>();
            _transform = GetComponent<Transform>();
        }

        public void Move(Vector2 position)
        {
            _transform.position = position;
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

        public void Collide(float damage)
        {
            Collided?.Invoke(damage);
        }
    }
}