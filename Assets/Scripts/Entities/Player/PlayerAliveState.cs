using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAliveState : StateBase<Player>
{
    public override void OnEnabled(Player context)
    {
        context.animator.SetBool("Dead", false);
        context.rigidbody.bodyType = RigidbodyType2D.Dynamic;
        context.isPlayerDead = false;
        base.OnEnabled(context);
    }

    public override void OnUpdate(Player context)
    {
        float inputHorizontalAxis = Input.GetAxis("Horizontal");
        context.animator.SetInteger("SightDirection", RoundDirection(inputHorizontalAxis) * -1);
        context.transform.Rotate(Vector3.forward * context.turnSpeed * inputHorizontalAxis * Time.deltaTime);
        base.OnUpdate(context);
    }

    private int RoundDirection(float value)
    {
        if (value > 0.0f)
        {
            return Mathf.CeilToInt(value);
        }
        else if (value < 0.0f)
        {
            return Mathf.FloorToInt(value);
        }
        else
        {
            return 0;
        }
    }
}
