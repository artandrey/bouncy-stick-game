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

    protected override void OnPlayerEnter(Player player)
    {
        stateMachine.CurrentState.OnPlayerEnter(player, this);
    }

    private float GetPlayerHeight(Player player)
    {
        var transform = player.transform;
        var collider = player.GetComponent<Collider2D>();
        return collider.bounds.size.y;
    }

    public void SetState(BearTrapStateBase state)
    {
        stateMachine.SetState(state);
    }
}
