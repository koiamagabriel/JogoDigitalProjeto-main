using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MalletMouseControl : MonoBehaviour
{
    public float xMin = -4.3f;
    public float xMax = 4.3f;
    public float yMin = -2.8f;
    public float yMax = -0.2f;

    private Rigidbody2D rb;
    private Camera cam;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        if (cam == null) return;

        Vector3 mouseScreen = Input.mousePosition;
        Vector3 mouseWorld = cam.ScreenToWorldPoint(mouseScreen);

        Vector2 target = new Vector2(
            Mathf.Clamp(mouseWorld.x, xMin, xMax),
            Mathf.Clamp(mouseWorld.y, yMin, yMax)
        );

        rb.MovePosition(target);
    }
}