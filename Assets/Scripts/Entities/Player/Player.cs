using System;
using UnityEngine;

public class Player : MonoBehaviour, IEntity
{

    [SerializeField]
    internal float turnSpeed = 250f;

    [SerializeField]
    internal AudioSource knockAudioSource;

    internal new Rigidbody2D rigidbody;

    internal bool isPlayerDead = false;

    internal Animator animator;

    public Action OnPlayerDeath { get; set; }

    public Action OnPlayerDeathStart { get; set; }

    private FiniteStateMachine<Player, StateBase<Player>> stateMachine;

    internal readonly PlayerAliveState aliveState = new();

    internal readonly PlayerDeadState deadState = new();

    internal readonly PlayerDyingState dyingState = new();

    public Player()
    {
        stateMachine = new(this);
    }

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        stateMachine.SetState(aliveState);
    }

    void Update()
    {
        stateMachine.OnUpdate();
    }

    public void DispatchDeath()
    {
        stateMachine.SetState(deadState);
    }

    public void DispatchDeathStart()
    {
        stateMachine.SetState(dyingState);
    }

    public void DispatchAlive()
    {
        stateMachine.SetState(aliveState);
    }

    [Obsolete]
    public void OnCollisionEnter2D(Collision2D collision)
    {
        animator.SetTrigger("Jump");
        knockAudioSource.pitch = UnityEngine.Random.RandomRange(0.1f, 0.02f);
        knockAudioSource.Play();
    }

    public void Die()
    {
        DispatchDeathStart();
    }
}
