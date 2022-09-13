using UnityEngine;

public abstract class Transition : MonoBehaviour
{
    [SerializeField] private EnemyState _targetState;

    protected ITarget Target { get; private set; }

    public EnemyState TargetState => _targetState;
    public bool NeedTransit { get; protected set; }
    
    private void OnEnable()
    {
        NeedTransit = false;
    }
    
    public void Init(ITarget target) => Target = target;
}
