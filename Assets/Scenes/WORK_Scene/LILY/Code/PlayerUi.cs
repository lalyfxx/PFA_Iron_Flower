using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    public Animator flowerAnimator; // Assigne dans l’inspecteur
    private PlayerMovment_2 player;
    public Vector3 lastCheckpointPos;

    void Awake()
    {
        player = FindAnyObjectByType<PlayerMovment_2>();
    }

    public void UpdateLives(int lives)
    {
        // Met à jour le paramètre de l’Animator
        flowerAnimator.SetInteger("currentLives", lives);

        // Remet le joueur au checkpoint
        player.transform.position = lastCheckpointPos;
    }

    public int GetCurrentLives()
    {
        return flowerAnimator.GetInteger("currentLives");
    }
}
