using UnityEngine;

public class DamageOnContact : MonoBehaviour
{
    public ParticleSystem particle;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody.CompareTag("Player"))
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();
            if (health != null)
            {
                health.TakeDamage(1);
            }
        }
        CreateDust();
    }

    void CreateDust()
    {
        if (particle == null)
            return;

        particle?.Play();
    }
}
