using UnityEngine;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PlayerHealth : MonoBehaviour
{
    public int maxLives = 3;
    private int currentLives;

    private PlayerUI playerUI;

    public Animator animator;

    public AudioSource damageSound; 

    void Start()
    {
        currentLives = maxLives;
        playerUI = FindAnyObjectByType<PlayerUI>();
        if (playerUI != null)
        {
            playerUI.UpdateLives(currentLives);
        }
        animator.SetInteger("currentLives", currentLives);
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
            SceneManager.LoadScene(5);
        }

        print(currentLives);
        animator.SetInteger("currentLives", currentLives);

        damageSound.Play();



    }

#if UNITY_EDITOR
    [CustomEditor(typeof(PlayerHealth))]
    class MyEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (GUILayout.Button("KIIIILL!!!"))
                (target as PlayerHealth).TakeDamage(10000);
        }
    }
#endif
}
