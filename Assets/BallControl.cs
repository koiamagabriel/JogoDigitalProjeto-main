using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rb2d; // Corpo rígido da bola

    // Inicializa a bola randomicamente para esquerda ou direita
    void GoBall()
    {
        float rand = Random.Range(0f, 2f);

        if (rand < 1f)
            rb2d.AddForce(new Vector2(20, -15));
        else
            rb2d.AddForce(new Vector2(-20, -15));
    }

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Invoke("GoBall", 2f); // lança após 2 segundos
    }

    // Comportamento da bola ao colidir com as raquetes
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.collider.CompareTag("Player"))
        {
            Vector2 vel;
            vel.x = rb2d.linearVelocity.x;
            vel.y = (rb2d.linearVelocity.y / 2f) + (coll.collider.attachedRigidbody.linearVelocity.y / 3f);
            rb2d.linearVelocity = vel;
        }
    }

    // Reinicializa posição e velocidade da bola
    public void ResetBall()
    {
        rb2d.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
    }

    // Reinicializa o jogo
    public void RestartGame()
    {
        ResetBall();
        Invoke("GoBall", 1f);
    }
}