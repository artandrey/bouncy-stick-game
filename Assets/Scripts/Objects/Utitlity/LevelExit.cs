using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    public event Action OnExit;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(Tags.PLYAER))
        {
            OnExit?.Invoke();
        }
    }
}
