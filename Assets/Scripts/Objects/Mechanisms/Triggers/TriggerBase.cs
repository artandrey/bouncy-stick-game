
using System;
using UnityEngine;

public abstract class TriggerBase : MonoBehaviour, ITrigger
{
    public Action OnActivated { get; set; }
    public Action OnDeactivated { get; set; }



    protected internal void DispatchActivated()
    {
        OnActivated?.Invoke();
    }

    protected internal void DispatchDeactivated()
    {
        OnDeactivated?.Invoke();
    }

    public abstract bool IsActivated();

    protected bool CheckIsTriggeredBy(Behaviour behaviour)
    {
        return behaviour.CompareTag(Tags.PLYAER);
    }
}
