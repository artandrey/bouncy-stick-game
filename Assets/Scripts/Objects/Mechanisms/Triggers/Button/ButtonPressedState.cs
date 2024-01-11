using UnityEngine;

public class ButtonPressedState : TriggerBaseState<Button>
{
    private float timer = 0;
    public override void OnEnabled(Button context)
    {
        timer = context.UnpressDelay;
        context.DispatchActivated();
        context.ButtonAnimator.SetBool("IsPressed", true);
        base.OnEnabled(context);
    }

    public override void OnUpdate(Button context)
    {
        if (timer <= 0)
        {
            context.SetState(context.UnpressedState);
        }
        else
        {
            timer -= Time.deltaTime;
        }
        base.OnUpdate(context);
    }
}
