

public class TargetDieTransition : Transition
{
    private void Update()
    {
        if (Target.Equals(null))
        {
            NeedTransit = true;
        }
    }
}
