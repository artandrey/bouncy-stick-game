using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanOffState : StateBase<FanObject>
{
    public override void OnEnabled(FanObject context)
    {
        context.isEnabled = false;
        context.FanAnimator.SetBool("IsSpinning", false);
        context.AreaEffector.forceMagnitude = 0;
        context.DisableParticles();
        base.OnEnabled(context);
    }
}
