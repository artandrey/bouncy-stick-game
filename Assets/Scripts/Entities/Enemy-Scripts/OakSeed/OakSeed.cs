using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OakSeed : MonoBehaviour
{
    private readonly OakSeedDestroyState destroyState = new();
    private readonly OakSeedIdleState idleState = new();
    private FiniteStateMachine<OakSeed, StateBase<OakSeed>> stateMachine;

    internal Animator animator;

    [SerializeField]
    internal float delay = 3f;

    public OakSeed()
    {
        stateMachine = new(this);
    }

    void Start()
    {
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
        Destroy(this);
    }

}
