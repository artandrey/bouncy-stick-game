using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FanObject : MonoBehaviour, IActivable
{


    private readonly FanOffState offState = new();
    private readonly FanOnState onState = new();

    internal AreaEffector2D AreaEffector { get; set; }
    internal float AreaEffectorForceMagnitude { get; private set; }
    internal Animator FanAnimator { get; private set; }

    private ParticleSystem levitatingParticleSystem;

    [SerializeField]
    internal bool isEnabled;

    private FiniteStateMachine<FanObject, StateBase<FanObject>> stateMachine;

    public FanObject()
    {
        stateMachine = new(this);
    }

    void Start()
    {
        AreaEffector = GetComponent<AreaEffector2D>();
        FanAnimator = GetComponent<Animator>();
        levitatingParticleSystem = GetComponentInChildren<ParticleSystem>();
        AreaEffectorForceMagnitude = AreaEffector.forceMagnitude;
        if (isEnabled)
        {
            stateMachine.SetState(onState);
        }
        else
        {
            stateMachine.SetState(offState);
        }
    }

    public void On()
    {
        stateMachine.SetState(onState);
    }

    public void Off()
    {
        stateMachine.SetState(offState);
    }

    internal void EnableParticles()
    {
        levitatingParticleSystem.gameObject.SetActive(true);
    }

    internal void DisableParticles()
    {
        levitatingParticleSystem.gameObject.SetActive(false);

    }

}
