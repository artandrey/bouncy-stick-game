using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jump : MonoBehaviour
{
    // Start is called before the first frame update
    public float thrust = 8.0f;
    public float angle = 0f;

    public float boostX = 0;

    public Rigidbody2D rb;


    void Start()
    {

    }




    void OnCollisionEnter2D(Collision2D collision)
    {
        float radiansAngleIncludingRotation = (rb.transform.rotation.eulerAngles.z + angle) * Mathf.Deg2Rad;

        float boostXQ = boostX + 1;

        rb.AddForce(new Vector2(Mathf.Cos(radiansAngleIncludingRotation) * thrust * boostX,
        Mathf.Sin(radiansAngleIncludingRotation) * thrust), ForceMode2D.Impulse);

    }
}
