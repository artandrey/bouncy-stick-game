using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTransition : MonoBehaviour
{
    [SerializeField]
    private LoadScreenControl loadScreenControl;

    [SerializeField]
    private Transform point;

    public LayerMask layerMask;


    void Start()
    {
        loadScreenControl.onScreenOffEnded += LevelTransit;
    }


    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log(collision.gameObject.name);
        if ((layerMask.value & (1 << collision.gameObject.transform.gameObject.layer)) > 0)
        {
            loadScreenControl.ScreenOn();
            Time.timeScale = 0;
            collision.transform.position = point.position;
        }

    }

    private void LevelTransit()
    {
        Debug.Log("transit");

        Time.timeScale = 1;
    }
}
