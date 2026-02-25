using UnityEngine;

public class SideWall : MonoBehaviour
{
    // Verifica colisão da bola nas paredes laterais
    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.tag == "Ball")
        {
            string wallName = transform.name;
            GameManager.Score(wallName);
            hitInfo.gameObject.SendMessage("RestartGame", null, SendMessageOptions.RequireReceiver);
        }
    }
}