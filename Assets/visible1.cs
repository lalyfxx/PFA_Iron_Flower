using UnityEngine;

public class visible1 : MonoBehaviour
{
    public float toggleCooldown = 0.2f;

    [SerializeField] GameObject visibilite;
    [SerializeField] GameObject invisible;
    private int state;

    float lastActivationTime = -1f;

    void TryToggle()
    {
        var elapsed = Time.time - lastActivationTime;
        if (elapsed < toggleCooldown)
            return;

        if (state % 2 == 0)
        {
            visibilite.SetActive(true);
            invisible.SetActive(false);
        }
        else
        {
            visibilite.SetActive(false);
            invisible.SetActive(true);
        }

        state += 1;
        lastActivationTime = Time.time;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player") == true)
            TryToggle();
    }
}
