using UnityEngine;

public class cinematique : MonoBehaviour
{
    public Animator animator;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player"))
        {
            animator.SetBool("Joue", true);
        }
    }
}