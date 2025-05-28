using UnityEngine;

public class oui : MonoBehaviour
{
    [SerializeField] GameObject visibilite;
    [SerializeField] GameObject invisible;
    [SerializeField] GameObject invisible2;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player") == false)
            return;

        if (collision.attachedRigidbody.CompareTag("Player") == true)
            visibilite.SetActive(false);
        invisible.SetActive(true);
        invisible2.SetActive(false);

    }
}
