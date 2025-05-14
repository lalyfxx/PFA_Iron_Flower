using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;

    void Start()
    {
        currentLives = maxLives;
        Debug.Log( "j'ai toutes mes vies" + currentLives );
    }

    public void TakeDamage(int amount)
    {
        currentLives -= amount;
        Debug.Log("vies restantes" + currentLives);

        if (currentLives <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Game Over !");
        Time.timeScale = 0f;
    }
}

