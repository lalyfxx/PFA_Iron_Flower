using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CH_Scene : MonoBehaviour
{
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(2);
        }
    }
}
