using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    // Start is called before the first frame update
    public float thrust = 8.0f;
    public float angle = 0f;

    public float boostX = 0;

    public Rigidbody2D rb;

<<<<<<< HEAD:Assets/Scripts/Player/Jump.cs

    void Start()
    {

    }

=======
>>>>>>> added trap changed player:Assets/Scripts/Entities/Player/Jump.cs
    void OnCollisionEnter2D(Collision2D collision)
    {
        float radiansAngleIncludingRotation = (rb.transform.rotation.eulerAngles.z + angle) * Mathf.Deg2Rad;

        float boostXQ = boostX * (1 - Mathf.Cos(radiansAngleIncludingRotation)) + 1;

        rb.AddForce(new Vector2(Mathf.Cos(radiansAngleIncludingRotation) * thrust * boostX,
        Mathf.Sin(radiansAngleIncludingRotation) * thrust), ForceMode2D.Impulse);

    }
}
