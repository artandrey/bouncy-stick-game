using UnityEngine;

public class Button : TriggerBase
{
    internal readonly ButtonPressedState PressedState = new();
    internal readonly ButtonUnpressedState UnpressedState = new();
    private FiniteStateMachine<Button, TriggerBaseState<Button>> stateMachine;

    [SerializeField]
    public bool IsPressed;

    [SerializeField]
    internal float UnpressDelay;
    internal Animator ButtonAnimator { get; private set; }

    public Button()
    {
        stateMachine = new(this);
    }

    void Start()
    {
        ButtonAnimator = GetComponent<Animator>();
        stateMachine.SetState(IsPressed ? PressedState : UnpressedState);
    }

    void Update()
    {
        stateMachine.OnUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (CheckIsTriggeredBy(collider))
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
