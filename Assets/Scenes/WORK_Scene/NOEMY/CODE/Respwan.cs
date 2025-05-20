using UnityEngine;

public class Respwan : MonoBehaviour
{
    public GameObject player;
    public Transform respawnpoint;

    private void OnCollisionEnter2D(Collision2D Other)
    {
        if (Other.gameObject.CompareTag("Player"))
        {
            player.transform.position = respawnpoint.position;
        }
    }
}
