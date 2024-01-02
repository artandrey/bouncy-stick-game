using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rigidbody2d;
    public float mainThrust;
    public float sideThrust;
    // Start is called before the first frame update
    void Start()
    {
     rigidbody2d = player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame


    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (name)
        {
            case ("top"):
                rigidbody2d.AddForce(player.transform.up * -mainThrust, ForceMode2D.Impulse);
                break;
            case ("bottom"):
                rigidbody2d.AddForce(player.transform.up * mainThrust, ForceMode2D.Impulse);
                break;
            case ("rigth"):
                rigidbody2d.AddForce(player.transform.right * -sideThrust, ForceMode2D.Impulse);
                break;
            case ("left"):
                rigidbody2d.AddForce(player.transform.right * sideThrust, ForceMode2D.Impulse);
                break;
        }
    }



}
