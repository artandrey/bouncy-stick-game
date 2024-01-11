using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{

    internal float timer = 0;

    [SerializeField]
    internal float throwDelay;

    [SerializeField]
    private float throwForce;
    [SerializeField]
    private GameObject throwedObject;
    [SerializeField]
    private Transform throwPoint;

    [SerializeField]
    private float throwedSize = 0.4f;

    internal SquirrelIdleState idleState = new();
    internal SquirrelThrowingState throwingState = new();

    private FiniteStateMachine<Squirrel, StateBase<Squirrel>> stateMachine;

    internal Animator squirrelAnimator;

    public Squirrel()
    {
        stateMachine = new(this);
    }

    void Start()
    {
        squirrelAnimator = GetComponent<Animator>();
        stateMachine.SetState(idleState);
    }

    void Update()
    {
        stateMachine.OnUpdate();
    }

    internal void StartThrow()
    {
        stateMachine.SetState(throwingState);
    }

    private void OnTrow()
    {
        GameObject instance = Instantiate(throwedObject);

        instance.transform.position = throwPoint.position;
        instance.transform.rotation = throwPoint.rotation;

        Rigidbody2D rigidbody = instance.GetComponent<Rigidbody2D>();

        Vector2 throwDirection = new Vector2(Mathf.Cos(throwPoint.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin(throwPoint.eulerAngles.z * Mathf.Deg2Rad));

        rigidbody.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
        stateMachine.SetState(idleState);
    }
}
