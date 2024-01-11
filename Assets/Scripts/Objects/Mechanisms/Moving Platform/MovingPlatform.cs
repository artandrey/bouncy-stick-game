using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IActivable
{
    [SerializeField]
    internal Transform platform;
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform endPoint;
    [SerializeField]
    internal float speed = 1.5f;
    [SerializeField]
    private bool cycleMove = false;
    [SerializeField]
    internal bool IsEnabled { get; set; }
    [SerializeField]
    private bool initialyTransformToCurrentTarget;

    internal Transform CurrentMovementTraget { get => direction == 1 ? endPoint : startPoint; }

    internal int direction = 1;

    private FiniteStateMachine<MovingPlatform, StateBase<MovingPlatform>> stateMachine;

    internal readonly PlatformCycleMovingState cycleMovingState = new();

    internal readonly PlatformMovingState movingState = new();
    internal readonly PlatformPausedState pausedState = new();

    public MovingPlatform()
    {
        stateMachine = new(this);
    }

    void Start()
    {
        if (initialyTransformToCurrentTarget)
        {
            platform.position = CurrentMovementTraget.position;
        }
        if (!IsEnabled)
        {
            stateMachine.SetState(pausedState);
        }
        if (cycleMove)
        {
            stateMachine.SetState(cycleMovingState);
        }
    }

    private void Update()
    {
        stateMachine.OnUpdate();
    }

    internal void ToggleDirection()
    {
        direction *= -1;
    }

    internal void SetDirection(MovingDirection direction)
    {
        this.direction = (int)direction;
    }

    public void Off()
    {
        SetDirection(MovingDirection.BACKWARD);
        stateMachine.SetState(movingState);
    }

    public void On()
    {
        SetDirection(MovingDirection.FORWARD);
        stateMachine.SetState(movingState);
    }

    public void SetIsInitiallyActive(bool isActive)
    {
        IsEnabled = isActive;
    }

    private void OnDrawGizmos()
    {
        if (platform != null && startPoint != null && endPoint != null)
        {
            Gizmos.DrawLine(platform.transform.position, startPoint.position);
            Gizmos.DrawLine(platform.transform.position, endPoint.position);
        }
    }
}
