using UnityEngine;

public class CameraScript : MonoBehaviour
{
    internal float initialSize;
    internal Camera gameCamera;

    private FiniteStateMachine<CameraScript, StateBase<CameraScript>> stateMachine;
    private readonly CameraInitialState initialState = new();
    private readonly CameraScalingUpState scalingUpState = new();

    public CameraScript()
    {
        stateMachine = new(this);
    }

    [SerializeField]
    internal float minScale;

    [SerializeField]
    internal float scalingSpeed = 0.1f;
    void Start()
    {
        gameCamera = GetComponent<Camera>();
        initialSize = gameCamera.orthographicSize;
        stateMachine.SetState(initialState);
    }

    void Update()
    {
        stateMachine.OnUpdate();
    }

    public void ScaleUp()
    {
        stateMachine.SetState(scalingUpState);
    }

    public void Reset()
    {
        stateMachine.SetState(initialState);
    }

}
