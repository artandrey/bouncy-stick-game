using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDyingState : StateBase<Player>
{
    public override void OnEnabled(Player context)
    {
        context.rigidbody.bodyType = RigidbodyType2D.Static;
        context.isPlayerDead = true;
        context.OnPlayerDeathStart?.Invoke();
        context.animator.SetBool("Dead", true);
        base.OnEnabled(context);
    }
}
