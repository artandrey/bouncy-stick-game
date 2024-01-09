
using System;
using UnityEngine;

public abstract class TriggerBase : MonoBehaviour, ITrigger
{
    public Action OnActivated { get; private set; }
    public Action OnDeactivated { get; private set; }

    protected internal void DispatchActivated()
    {
        OnActivated?.Invoke();
    }

    protected internal void DispatchDeactivated()
    {
        OnDeactivated?.Invoke();
    }
}
