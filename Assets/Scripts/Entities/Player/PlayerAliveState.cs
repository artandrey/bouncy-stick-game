using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAliveState : StateBase<Player>
{
    public override void OnUpdate(Player context)
    {
        context.transform.Rotate(Vector3.forward * context.turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        base.OnUpdate(context);
    }
}
