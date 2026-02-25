using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PuckSpeedLimiter : MonoBehaviour
{
    public float maxSpeed = 10f;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }
    }
}