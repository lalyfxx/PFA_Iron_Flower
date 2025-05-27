using UnityEngine;
using UnityEngine.SceneManagement;

public class cinematique : MonoBehaviour
{
    public Animator animator;

    void Start()
    {

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player"))
        {

            // Jouer l'animation
            animator.SetBool("Joue", true);

            // Appeler la méthode pour changer de scène après la durée de l'animation
            // Invoke("ChangeScene", animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }
}