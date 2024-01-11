using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Jump : MonoBehaviour
{
    public float timer = 0;

    public float throttle = 0.2f;
    public float thrust = 8.0f;
    public float angle = 0f;

    public bool CanJump { get => timer <= 0; }

    public float boostX = 0;

    public Rigidbody2D rb;

    void Update()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (!CanJump) return;

        float radiansAngleIncludingRotation = (rb.transform.rotation.eulerAngles.z + angle) * Mathf.Deg2Rad;

        float boostXQ = boostX * (1 - Mathf.Cos(radiansAngleIncludingRotation)) + 1;

        rb.AddForce(new Vector2(Mathf.Cos(radiansAngleIncludingRotation) * thrust * boostX,
        Mathf.Sin(radiansAngleIncludingRotation) * thrust), ForceMode2D.Impulse);
        timer = throttle;

    }
}
