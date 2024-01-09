
using System;
using UnityEngine;

public abstract class TriggerBase : MonoBehaviour, ITrigger
{
    public Action OnActivated { get; private set; }
    public Action OnDeactivated { get; private set; }

    public void DispatchActivated()
    {
        OnActivated?.Invoke();
    }

    public void DispatchDeactivated()
    {
        OnDeactivated?.Invoke();
    }
}
