using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivableConnection : MonoBehaviour
{

    [SerializeField]
    private IRef<IActivable> _activable;

    [SerializeField]
    private IRef<ITrigger> _trigger;

    private IActivable Activable { get => _activable.I; }
    public ITrigger Trigger { get => _trigger.I; }


    void Start()
    {
        Activable.SetIsInitiallyActive(Trigger.IsActivated());
        Trigger.OnActivated += Activable.On;
        Trigger.OnDeactivated += Activable.Off;
    }

    void OnDestroy()
    {
        Trigger.OnActivated -= Activable.On;
        Trigger.OnDeactivated -= Activable.Off;
    }

}
