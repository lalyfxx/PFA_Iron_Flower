using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class EndVideo : MonoBehaviour
{
    private VideoPlayer videoPlayer;
    private bool hasEnded = false;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        if (videoPlayer != null)
        {
            videoPlayer.loopPointReached += OnVideoEnd;
        }
        else
        {
            Debug.LogError("Aucun VideoPlayer trouvé sur cet objet.");
        }
    }

    void Update()
    {
        if (!hasEnded && (Input.anyKeyDown || Input.GetMouseButtonDown(0)))
        {
            LoadScene();
        }
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        LoadScene();
    }

    void LoadScene()
    {
        hasEnded = true;
        SceneManager.LoadScene(1);
    }
}