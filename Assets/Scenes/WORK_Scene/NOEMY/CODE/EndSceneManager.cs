using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class EndSceneManager : MonoBehaviour
{
    public CanvasGroup fadeCanvas;
    public float fadeDuration = 1f;

    public void StartFadeToCredits()
    {
        StartCoroutine(FadeAndLoadCredits());
    }

    private IEnumerator FadeAndLoadCredits()
    {
        float t = 0f;
        while (t < fadeDuration)
        {
            t += Time.deltaTime;
            fadeCanvas.alpha = Mathf.Lerp(0, 1, t / fadeDuration);
            yield return null;
        }

        // Charge la scène des crédits (remplace "CreditsScene" par le nom réel)
        SceneManager.LoadScene(7);
    }
}
