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

    internal SquirrelIdleState idleState = new();
    internal SquirrelThrowingState throwingState = new();

    private FiniteStateMachine<Squirrel, StateBase<Squirrel>> stateMachine;

    private Animator squirrelAnimator;

    void Start()
    {
        squirrelAnimator = GetComponent<Animator>();
    }

    void Update()
    {

    }

    internal void StartThrow()
    {

    }

    private void OnTrow()
    {
        GameObject instance = Instantiate(throwedObject);

        instance.transform.position = throwPoint.position;
        instance.transform.rotation = throwPoint.rotation;

        Rigidbody2D rigidbody = instance.GetComponent<Rigidbody2D>();

        Vector2 throwDirection = new Vector2(Mathf.Cos(throwPoint.eulerAngles.z * Mathf.Deg2Rad), Mathf.Sin(throwPoint.eulerAngles.z * Mathf.Deg2Rad));

        rigidbody.AddForce(throwDirection * throwForce, ForceMode2D.Impulse);
    }
}
