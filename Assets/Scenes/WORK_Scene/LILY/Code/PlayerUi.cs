using UnityEngine;
using TMPro;

public class PlayerUI : MonoBehaviour
{
    public TMP_Text livesText;
    private PlayerMovment_2 player;
    public Vector3 lastCheckpointPos;

    void Awake()
    {
        player = FindAnyObjectByType<PlayerMovment_2>();
    } 
    public void UpdateLives(int lives)
    {
        livesText.text = "Vies : " + lives.ToString();
        player.transform.position = lastCheckpointPos;
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
