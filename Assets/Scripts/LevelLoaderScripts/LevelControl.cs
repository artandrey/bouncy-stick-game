using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelControl : MonoBehaviour
{
    [SerializeField]
    private Transform startPoint;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Initialize(GameObject player)
    {
        player.transform.position = startPoint.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
