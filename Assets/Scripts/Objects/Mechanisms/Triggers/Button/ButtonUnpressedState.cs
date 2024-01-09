public class ButtonUnpressedState : TriggerBaseState<Button>
{
    public override void OnEnabled(Button context)
    {
        context.DispatchDeactivated();
        context.ButtonAnimator.SetBool("IsPressed", false);
        base.OnEnabled(context);
    }

    public override void OnTirggered(Button context)
    {
        context.SetState(context.PressedState);
        base.OnTirggered(context);
    }
}
