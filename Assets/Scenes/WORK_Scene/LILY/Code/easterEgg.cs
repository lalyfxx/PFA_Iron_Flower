using UnityEngine;

public class easterEgg : MonoBehaviour
{
    public AudioSource music;
    public AudioSource musictrap;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.LeftShift)))
        {
            music.Stop();
            musictrap.Play();
        }
    }
}
