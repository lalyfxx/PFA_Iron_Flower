using UnityEngine;
using UnityEngine.SceneManagement;

public class cinematique : MonoBehaviour
{
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player"))
        {
            // Jouer l'animation
            animator.SetTrigger("PlayAnimation");

            // Appeler la méthode pour changer de scène après la durée de l'animation
            Invoke("ChangeScene", animator.GetCurrentAnimatorStateInfo(0).length);
        }
    }

    void ChangeScene()
    {
        SceneManager.LoadScene(7);
    }
}