using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInitialState : StateBase<CameraScript>
{
    public override void OnEnabled(CameraScript context)
    {
        context.gameCamera.orthographicSize = context.initialSize;
        base.OnEnabled(context);
    }
}
