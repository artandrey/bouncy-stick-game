using UnityEngine;

public class Button : TriggerBase
{
    private readonly ButtonPressedState pressedState = new();
    private readonly ButtonUnpressedState unpressedState = new();
    private FiniteStateMachine<Button, TriggerBaseState<Button>> stateMachine;

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
        stateMachine.SetState(unpressedState);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(Tags.PLYAER))
        {
            stateMachine.SetState(pressedState);
        }
    }
}
