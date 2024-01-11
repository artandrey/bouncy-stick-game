using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScalingUpState : StateBase<CameraScript>
{
    public override void OnUpdate(CameraScript context)
    {
        if (context.gameCamera.orthographicSize < context.minScale) return;
        context.gameCamera.orthographicSize -= context.scalingSpeed * Time.deltaTime;
        base.OnUpdate(context);
    }
}
