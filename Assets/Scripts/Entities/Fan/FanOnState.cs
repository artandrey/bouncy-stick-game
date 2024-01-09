using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanOnState : StateBase<FanObject>
{
    public override void OnEnabled(FanObject context)
    {
        context.isEnabled = true;
        context.FanAnimator.SetBool("IsSpinning", true);
        context.AreaEffector.forceMagnitude = context.AreaEffectorForceMagnitude;
        context.EnableParticles();
        base.OnEnabled(context);
    }
}
