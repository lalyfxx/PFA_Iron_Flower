using UnityEngine;

public class Audio_Int : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource ecran;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.attachedRigidbody.CompareTag("Player"))
        {
            Music.Play();
            ecran.Play();
        }
    }


    void Update()
    {
        
    }
}