using UnityEngine;

public class Audio_Ext : MonoBehaviour
{
    public AudioSource Wind;
    public AudioSource music;

    private void OnTriggerEnter2D(Collider2D other){
        
        if (other.attachedRigidbody.CompareTag("Player"))
        {
            Wind.Stop();
            music.Stop();
        }
    }

    void Update()
    {
        
    }
}
