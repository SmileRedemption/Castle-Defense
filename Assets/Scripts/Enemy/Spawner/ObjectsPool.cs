using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class ObjectsPool<T> : MonoBehaviour
    where T : MonoBehaviour, ISpawnable 
{
    [SerializeField] private int _capacity;
    [SerializeField] private Transform _container;

    private readonly List<T> _pool = new List<T>();

    protected Vector3 GetPositionOfContainer()
    {
        return _container.position;
    }
    
    protected void Initialize(T prefab)
    {
        for (var i = 0; i < _capacity; i++)
        {
            var spawned = Instantiate(prefab, _container.transform);
            spawned.SetActive(false);
        
            _pool.Add(spawned);
        }
    }
    
    protected void Initialize(T[] prefabs)
    {
        for (var i = 0; i < _capacity; i++)
        {
            var indexOfSpawnObject = Random.Range(0, prefabs.Length);
            var spawned = Instantiate(prefabs[indexOfSpawnObject], _container.transform);
            spawned.SetActive(false);
        
            _pool.Add(spawned);
        }
    }
    
    protected bool TryGetObject(out T objectOfPool)
    {
        objectOfPool = _pool.FirstOrDefault(element => element.gameObject.activeSelf == false);
        return objectOfPool != null;
    }
}
