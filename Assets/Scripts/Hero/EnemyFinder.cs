using UnityEngine;

public class EnemyFinder : MonoBehaviour
{
    [SerializeField] private float _rayDistance;

    private Transform _transform;

    private void Awake()
    {
        _transform = GetComponent<Transform>();
    }
    
    public bool TryFindEnemy(out Enemy enemyTarget)
    {
        var hit = Physics2D.Raycast(_transform.position, Vector2.right, _rayDistance);

        if (hit)
        {
            return hit.collider.gameObject.TryGetComponent(out enemyTarget);
        }

        enemyTarget = null;
        
        return false;
    }
}
