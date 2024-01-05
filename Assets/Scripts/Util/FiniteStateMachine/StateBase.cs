using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StateBase<T>
{
    public virtual void OnEnabled(T context)
    {

    }

    public virtual void OnUpdate(T context)
    {

    }

}
