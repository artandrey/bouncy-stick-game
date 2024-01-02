using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadScreenControl : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    public event Action onScreenOffEnded;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ScreenOn()
    {
        animator.SetInteger("State", 1);
    }

    public void ScreenOffCompleted()
    {
        Debug.Log("ScreenOffCompleted");
        onScreenOffEnded?.Invoke();
        animator.SetInteger("State", 0);

    }


}
