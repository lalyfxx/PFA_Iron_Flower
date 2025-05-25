using UnityEngine;

public class visible1 : MonoBehaviour
{
    [SerializeField] GameObject visibilite;
    [SerializeField] GameObject invisible;
    private int x;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player") == false)
            return;
        if (collision.attachedRigidbody.CompareTag("Player") == true)
            if (x % 2 == 0)
            {
                visibilite.SetActive(true);
                invisible.SetActive(false);
            }
            else
            {
                visibilite.SetActive(false);
                invisible.SetActive(true);
            }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player") == false)
            return;
        if (collision.attachedRigidbody.CompareTag("Player") == true)
        {
            x += 1;
        } 
    }
}
