using System;
using UnityEngine;

public class LoadScreenControl : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

    public event Action onScreenOffEnded;

    public event Action onSreenOnEnded;

    public void ScreenOn()
    {
        animator.SetTrigger("ScreenOn");
    }

    public void ScreenOff()
    {
        animator.SetTrigger("ScreenOff");
    }

    public void ScreenOffCompleted()
    {
        onScreenOffEnded?.Invoke();
    }

    public void ScreenOnCompleted()
    {
        onSreenOnEnded?.Invoke();
    }
}