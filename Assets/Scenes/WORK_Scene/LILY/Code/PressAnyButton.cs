using UnityEngine;
using UnityEngine.SceneManagement;


public class PressAnyButton : MonoBehaviour
{
    private bool hasEnded = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!hasEnded && (Input.anyKeyDown || Input.GetMouseButtonDown(0)))
        {
            LoadScene();
        }
    }
    
    void LoadScene()
    {
        hasEnded = true;
        SceneManager.LoadSceneAsync(2);
    }
}
