using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaverOffState : TriggerBaseState<Leaver>
{
    public override void OnEnabled(Leaver context)
    {
        context.DispatchDeactivated();
        context.LeaverAnimator.SetBool("IsOn", false);
        base.OnEnabled(context);
    }

    public override void OnTirggered(Leaver context)
    {
        context.SetState(context.OnState);
        base.OnTirggered(context);
    }
}
