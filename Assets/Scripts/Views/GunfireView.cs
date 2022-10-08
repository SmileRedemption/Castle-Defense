using System;
using Spawner;
using UnityEngine;

namespace Views
{
    public class GunfireView : View, ISpawnable
    {
        public event Action<EnemyView> Collided;
        
        public void Move(Vector2 position)
        {
            transform.position = position;
        }
        
        public void TurnOff()
        {
            gameObject.SetActive(false);
        }

        public void TurnOn()
        {
            gameObject.SetActive(true);
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.TryGetComponent(out EnemyView enemyView))
            {
                Collided?.Invoke(enemyView);
            }
            
            TurnOff();
        }
    }
}