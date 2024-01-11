using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelExit : MonoBehaviour
{
    [SerializeField]
    private LevelLoader levelLoader;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag(Tags.PLYAER))
        {
            levelLoader.Next();
        }
    }
}
