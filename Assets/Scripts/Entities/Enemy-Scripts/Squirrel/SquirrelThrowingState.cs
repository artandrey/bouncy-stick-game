using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquirrelThrowingState : StateBase<Squirrel>
{
    public override void OnEnabled(Squirrel context)
    {
        context.squirrelAnimator.SetTrigger("Throw");
        base.OnEnabled(context);
    }
}
