using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


public class EndVideo2 : MonoBehaviour
{
    public GameObject splashToHide;

    private VideoPlayer videoPlayer;
    private bool hasEnded = false;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();

        videoPlayer.started += (vp) =>
        {
            if (splashToHide != null)
                splashToHide.SetActive(false);
        };

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
        SceneManager.LoadScene(3);
    }
}