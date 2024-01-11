using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OakSeedIdleState : StateBase<OakSeed>
{
    private float timer = 0;

    public override void OnEnabled(OakSeed context)
    {
        timer = context.delay;
        base.OnEnabled(context);
    }

    public override void OnUpdate(OakSeed context)
    {
        if (timer < 0)
        {
            context.SetState(context.destroyState);
        }
        else
        {
            timer -= Time.deltaTime;
        }
        base.OnUpdate(context);
    }
}
