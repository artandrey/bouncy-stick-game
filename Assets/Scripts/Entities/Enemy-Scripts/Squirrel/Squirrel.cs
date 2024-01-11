using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Squirrel : MonoBehaviour
{
    private float timer = 0;

    [SerializeField]
    private float throwDelay;

    [SerializeField]
    private float throwStrength;
    [SerializeField]
    private GameObject throwedObject;

    void Start()
    {

    }
    void Update()
    {
        if (timer < 0)
        {
            timer = throwDelay;
            OnTrow();
        }
    }

    protected void OnTrow()
    {

    }
}
