using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text livesText;

    public void UpdateLives(int lives)
    {
        livesText.text = "Vies : " + lives.ToString();
    }

    public int GetCurrentLives()
    {
        string[] parts = livesText.text.Split(':');
        if (parts.Length > 1 && int.TryParse(parts[1], out int currentLives))
        {
            return currentLives;
        }
        return 0;
    }
}
