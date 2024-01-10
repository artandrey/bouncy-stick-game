using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaver : TriggerBase
{
    internal readonly LeaverOffState OffState = new();
    internal readonly LeaverOnState OnState = new();

    private FiniteStateMachine<Leaver, TriggerBaseState<Leaver>> stateMachine;

    public Leaver()
    {
        stateMachine = new(this);
    }

    [SerializeField]
    public bool IsOn { get; set; }

    internal Animator LeaverAnimator { get; private set; }

    void Start()
    {
        LeaverAnimator = GetComponent<Animator>();
        stateMachine.SetState(IsOn ? OnState : OffState);
    }
    public override bool IsActivated()
    {
        return IsOn;
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (CheckIsTriggeredBy(collider))
        {
            stateMachine.CurrentState.OnTirggered(this);
        }
    }

    internal void SetState(TriggerBaseState<Leaver> state)
    {
        stateMachine.SetState(state);
    }

}
