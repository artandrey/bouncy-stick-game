using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMovingState : StateBase<MovingPlatform>
{
    public override void OnUpdate(MovingPlatform context)
    {
        Vector2 target = context.CurrentMovementTraget.position;

        context.platform.position = Vector2.Lerp(context.platform.position, target, context.speed * Time.deltaTime);

        base.OnUpdate(context);
    }
}
