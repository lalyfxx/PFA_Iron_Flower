using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;

    private PlayerUI playerUI;

    void Start()
    {
        currentLives = maxLives;
        playerUI = FindAnyObjectByType<PlayerUI>();
        if (playerUI != null)
        {
            playerUI.UpdateLives(currentLives);
        }
    }

    public void TakeDamage(int damage)
    {
        currentLives -= damage;
        currentLives = Mathf.Max(0, currentLives);

        if (playerUI != null)
        {
            playerUI.UpdateLives(currentLives);
        }

        if (currentLives <= 0)
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0f; 
        }
    }
}
