using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelIdleState : StateBase<Squirrel>
{
    public override void OnEnabled(Squirrel context)
    {
        context.timer = context.throwDelay;
        base.OnEnabled(context);
    }

    public override void OnUpdate(Squirrel context)
    {
        if (context.timer <= 0)
        {
            context.timer = context.throwDelay;
            context.StartThrow();
        }
        else
        {
            context.timer -= Time.deltaTime;
        }
        base.OnUpdate(context);
    }
}
