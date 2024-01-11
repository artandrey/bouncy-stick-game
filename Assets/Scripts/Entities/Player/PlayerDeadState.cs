using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeadState : StateBase<Player>
{
    public override void OnEnabled(Player context)
    {
        context.OnPlayerDeath?.Invoke();
        base.OnEnabled(context);
    }
}
