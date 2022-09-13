using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] private List<Transition> _transitions;

    protected ITarget Target { get; private set; }

    public void Enter(ITarget target)
    {
        if (enabled == false)
        {
            enabled = true;
            Target = target;
            
            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Target);
            }
        }
    }

    public void Exit()
    {
        if (enabled)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }
            
            enabled = false;
        }

    }

    public EnemyState GetNextState()
    {
        return (from transition in _transitions where transition.NeedTransit select transition.TargetState).FirstOrDefault();
    }
}