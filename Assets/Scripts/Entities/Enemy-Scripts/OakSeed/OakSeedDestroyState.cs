using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OakSeedDestroyState : StateBase<OakSeed>
{
    public override void OnEnabled(OakSeed context)
    {
        context.animator.SetTrigger("Destroy");
        base.OnEnabled(context);
    }
}
