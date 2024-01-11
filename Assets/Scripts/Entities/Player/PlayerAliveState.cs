using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAliveState : StateBase<Player>
{
    public override void OnEnabled(Player context)
    {
        context.animator.SetBool("Dead", false);
        context.rigidbody.bodyType = RigidbodyType2D.Dynamic;
        context.rigidbody.velocity = Vector2.zero;
        context.isPlayerDead = false;
        base.OnEnabled(context);
    }

    public override void OnUpdate(Player context)
    {
        context.transform.Rotate(Vector3.forward * context.turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        base.OnUpdate(context);
    }
}
