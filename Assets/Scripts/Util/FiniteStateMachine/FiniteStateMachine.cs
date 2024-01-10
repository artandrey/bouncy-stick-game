public class FiniteStateMachine<C, S> where S : StateBase<C>
{
    private S currentState;
    private C context;

    public FiniteStateMachine(C context)
    {
        this.context = context;
    }

    public S CurrentState
    {
        get => currentState;
    }

    public void OnUpdate()
    {
        currentState?.OnUpdate(context);
    }

    public void SetState(S state)
    {
        if (currentState == state) return;
        currentState = state;
        currentState?.OnEnabled(context);
    }

}
