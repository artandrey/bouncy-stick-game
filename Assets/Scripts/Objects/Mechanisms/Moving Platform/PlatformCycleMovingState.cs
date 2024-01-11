using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformCycleMovingState : PlatformMovingState
{
    public override void OnUpdate(MovingPlatform context)
    {
        base.OnUpdate(context);
        Vector2 target = context.CurrentMovementTraget.position;
        float distance = (target - (Vector2)context.platform.position).magnitude;
        if (distance <= 0.1f)
        {
            context.ToggleDirection();
        }
    }
}
