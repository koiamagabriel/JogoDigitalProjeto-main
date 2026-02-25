using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MalletAIControl : MonoBehaviour
{
    public float speed = 7f;

    // Limites do lado de cima (ajustamos melhor depois se precisar)
    public float xMin = -4.3f;
    public float xMax = 4.3f;
    public float yMin = 0.2f;
    public float yMax = 2.8f;

    private Rigidbody2D rb;
    private Transform puck;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        GameObject puckObj = GameObject.Find("Puck");
        if (puckObj != null)
            puck = puckObj.transform;
    }

    void FixedUpdate()
    {
        if (puck == null) return;

        Vector2 target = new Vector2(
            Mathf.Clamp(puck.position.x, xMin, xMax),
            Mathf.Clamp(puck.position.y, yMin, yMax)
        );

        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);
    }
}