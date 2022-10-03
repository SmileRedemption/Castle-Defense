using System.Collections.Generic;
using System.Linq;
using Setup;
using UnityEngine;
using Views;

namespace Spawner
{
    public abstract class ObjectsPool<T>  : MonoBehaviour
        where T : View, ISpawnable
    {
        [SerializeField] private int _capacity;
        [SerializeField] private Transform _container;

        private readonly List<T> _pool = new List<T>();

        private Vector3 GetPositionOfContainer()
        {
            return _container.position;
        }
    
        protected void Initialize(T prefab, Vector2 positionOfSpawn)
        {
            for (var i = 0; i < _capacity; i++)
            {
                var spawned = Create(prefab, positionOfSpawn);
                spawned.TurnOff();
                
                _pool.Add(spawned);
            }
        }

        protected bool TryGetObject(out T objectOfPool)
        {
            objectOfPool = _pool.FirstOrDefault(element => element.gameObject.activeSelf == false);
            return objectOfPool != null;
        }

        private T Create(T prefab, Vector2 position)
        {
            return Instantiate(prefab, position, Quaternion.identity);
        }
    }
}