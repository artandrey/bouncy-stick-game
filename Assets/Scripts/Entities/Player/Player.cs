using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField]
    private float turnSpeed = 250f;
    private new Rigidbody2D rigidbody;

    private bool isPlayerDead = false;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!isPlayerDead)
        {
            transform.Rotate(Vector3.forward * turnSpeed * Input.GetAxis("Horizontal") * Time.deltaTime);
        }
    }

    public void DispatchDeath()
    {
        rigidbody.bodyType = RigidbodyType2D.Static;
        isPlayerDead = true;
    }

    public void DispatchAlive()
    {
        rigidbody.bodyType = RigidbodyType2D.Kinematic;
        isPlayerDead = false;
    }
}
