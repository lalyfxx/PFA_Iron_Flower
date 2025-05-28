using UnityEngine;

public class LegsDamageForwarder : MonoBehaviour
{
    private PlayerHealth playerHealth;
    public AudioSource hittingLegs;

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
                hittingLegs.Play();
            }
        }
    }
}
