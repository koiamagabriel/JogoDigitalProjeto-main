using UnityEngine;

public class GoalResetTrigger : MonoBehaviour
{
    public string puckName = "Puck";
    public string bottomMalletName = "Mallet_Bottom";
    public string topMalletName = "Mallet_Top";

    public Vector3 puckResetPosition = Vector3.zero;
    public Vector3 bottomMalletResetPosition = new Vector3(0f, -4f, 0f);
    public Vector3 topMalletResetPosition = new Vector3(0f, 4f, 0f);

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name != puckName) return;

        // Reset puck
        Rigidbody2D puckRb = other.GetComponent<Rigidbody2D>();
        if (puckRb != null)
        {
            // Se der erro nessa linha na sua versão, troque por puckRb.velocity = Vector2.zero;
            puckRb.linearVelocity = Vector2.zero;
            puckRb.angularVelocity = 0f;
        }
        other.transform.position = puckResetPosition;

        // Reset mallet de baixo
        GameObject bottomMallet = GameObject.Find(bottomMalletName);
        if (bottomMallet != null)
        {
            Rigidbody2D rbBottom = bottomMallet.GetComponent<Rigidbody2D>();
            if (rbBottom != null)
            {
                rbBottom.linearVelocity = Vector2.zero;
                rbBottom.angularVelocity = 0f;
                rbBottom.MovePosition(bottomMalletResetPosition);
            }
            else
            {
                bottomMallet.transform.position = bottomMalletResetPosition;
            }
        }

        // Reset mallet de cima
        GameObject topMallet = GameObject.Find(topMalletName);
        if (topMallet != null)
        {
            Rigidbody2D rbTop = topMallet.GetComponent<Rigidbody2D>();
            if (rbTop != null)
            {
                rbTop.linearVelocity = Vector2.zero;
                rbTop.angularVelocity = 0f;
                rbTop.MovePosition(topMalletResetPosition);
            }
            else
            {
                topMallet.transform.position = topMalletResetPosition;
            }
        }
    }
}