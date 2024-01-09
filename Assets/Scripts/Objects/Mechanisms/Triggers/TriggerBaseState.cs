using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TriggerBaseState<C> : StateBase<C>
{
    public virtual void OnTirggered(C context)
    {

    }
}
