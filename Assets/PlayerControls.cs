using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    public KeyCode moveUp = KeyCode.W;      // Move a raquete para cima
    public KeyCode moveDown = KeyCode.S;    // Move a raquete para baixo
    public float speed = 10.0f;             // Velocidade da raquete
    public float boundY = 2.25f;            // Limite vertical

    private Rigidbody2D rb2d;               // Corpo rígido da raquete

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector2 vel = rb2d.linearVelocity;

        if (Input.GetKey(moveUp))
        {
            vel.y = speed;
        }
        else if (Input.GetKey(moveDown))
        {
            vel.y = -speed;
        }
        else
        {
            vel.y = 0;
        }

        rb2d.linearVelocity = vel;

        Vector3 pos = transform.position;

        if (pos.y > boundY)
            pos.y = boundY;
        else if (pos.y < -boundY)
            pos.y = -boundY;

        transform.position = pos;
    }
}