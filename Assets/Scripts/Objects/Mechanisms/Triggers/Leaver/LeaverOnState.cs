using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeaverOnState : TriggerBaseState<Leaver>
{
    public override void OnEnabled(Leaver context)
    {
        context.DispatchActivated();
        context.LeaverAnimator.SetBool("IsOn", true);
        base.OnEnabled(context);
    }

    public override void OnTirggered(Leaver context)
    {
        context.SetState(context.OffState);
        base.OnTirggered(context);
    }
}
