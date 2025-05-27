using UnityEngine;

public class LegsDamageForwarder : MonoBehaviour
{
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponentInParent<PlayerHealth>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) // ton ennemi doit avoir le tag "Enemy"
        {
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(1);
            }
        }
    }
}
