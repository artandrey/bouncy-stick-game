public class ButtonPressedState : TriggerBaseState<Button>
{
    public override void OnEnabled(Button context)
    {
        context.DispatchActivated();
        context.ButtonAnimator.SetBool("IsPressed", true);
        base.OnEnabled(context);
    }
}
