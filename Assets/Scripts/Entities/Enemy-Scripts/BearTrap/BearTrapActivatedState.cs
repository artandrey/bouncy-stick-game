

public class BearTrapActivatedState : BearTrapStateBase
{
    public override void OnEnabled(BearTrap context)
    {
        context.animator.SetBool("IsActivated", true);
        context.isActive = false;
        base.OnEnabled(context);
    }
}
