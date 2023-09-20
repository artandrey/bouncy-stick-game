using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    // Start is called before the first frame update
    public float thrust = 8.0f;
    public Rigidbody2D rb;

    void Start()
    {

    }




    void OnCollisionEnter2D(Collision2D collision)
    {
        string name = this.name;

        if (name == "collider-top")
        {
            rb.AddForce(-transform.up * thrust, ForceMode2D.Impulse);

        }
        else if (name == "collider-bottom")
        {
            rb.AddForce(transform.up * thrust, ForceMode2D.Impulse);
        }
    }
}
