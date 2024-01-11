using UnityEngine;



public class BearTrap : TrapBase
{

    public bool isActive { get; set; }
    public Animator animator { get; set; }

    private FiniteStateMachine<BearTrap, BearTrapStateBase> stateMachine;

    public BearTrap()
    {
        stateMachine = new(this);
    }

    void Start()
    {
        animator = GetComponent<Animator>();
        SetState(new BearTrapActiveState());
    }

    protected override void OnEntityEnter(IEntity entity)
    {
        stateMachine.CurrentState.OnPlayerEnter(entity, this);
    }

    private float GetPlayerHeight(IEntity entity)
    {
        var transform = entity.gameObject.transform;
        var collider = entity.gameObject.GetComponent<Collider2D>();
        return collider.bounds.size.y;
    }

    public void SetState(BearTrapStateBase state)
    {
        stateMachine.SetState(state);
    }
}
