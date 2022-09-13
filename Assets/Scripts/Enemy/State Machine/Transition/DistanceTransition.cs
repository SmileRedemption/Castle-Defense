using UnityEngine;

public class DistanceTransition : Transition
{
    [SerializeField] private float _transitionRange;
    [SerializeField] private float _rangeSpread;

    private void Start()
    {
        _transitionRange += Random.Range(-_rangeSpread, _rangeSpread);
    }

    private void Update()
    {
        if (Target.Equals(null))
        {
            NeedTransit = true;
            return;
        }
        
        if (Vector2.Distance(transform.position, Target.GetPosition()) < _transitionRange)
        {
            NeedTransit = true;
        }
    }
}
