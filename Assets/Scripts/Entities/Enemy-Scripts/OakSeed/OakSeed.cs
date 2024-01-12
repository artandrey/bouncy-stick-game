using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OakSeed : MonoBehaviour
{
    internal readonly OakSeedDestroyState destroyState = new();
    internal readonly OakSeedIdleState idleState = new();
    private FiniteStateMachine<OakSeed, StateBase<OakSeed>> stateMachine;

    internal Animator animator;

    [SerializeField]
    internal float delay = 3f;
    [SerializeField]
    internal bool disableTimeoutDestroy = false;

    public OakSeed()
    {
        stateMachine = new(this);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        stateMachine.SetState(idleState);
    }

    void Update()
    {
        stateMachine.OnUpdate();
    }

    public void SetState(StateBase<OakSeed> state)
    {
        stateMachine.SetState(state);
    }

    private void OnDestroyEnd()
    {
        Destroy(this.gameObject);
    }

}
