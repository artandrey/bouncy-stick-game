using UnityEngine;

public class Button : TriggerBase
{
    internal readonly ButtonPressedState PressedState = new();
    internal readonly ButtonUnpressedState UnpressedState = new();
    private FiniteStateMachine<Button, TriggerBaseState<Button>> stateMachine;

    [SerializeField]
    public bool IsPressed { get; set; }

    [SerializeField]
    internal float UnpressDelay { get; set; }
    internal Animator ButtonAnimator { get; private set; }

    public Button()
    {
        stateMachine = new(this);
    }

    void Start()
    {
        ButtonAnimator = GetComponent<Animator>();
        if (IsPressed)
        {
            stateMachine.SetState(PressedState);
        }
        else
        {
            stateMachine.SetState(UnpressedState);
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(Tags.PLYAER))
        {
            stateMachine.CurrentState.OnTirggered(this);
        }
    }

    public override bool IsActivated()
    {
        return IsPressed;
    }

    internal void SetState(TriggerBaseState<Button> state)
    {
        stateMachine.SetState(state);
    }

}
