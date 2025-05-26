using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int value;
    private bool hasTriggered;

    private CoinManager coinManager;

    public AudioSource coinSoundPrefab; 

    private void Start()
    {
        coinManager = CoinManager.instance;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player") && !hasTriggered)
        {
            hasTriggered = true;

            if (coinSoundPrefab != null)
            {
                AudioSource soundInstance = Instantiate(coinSoundPrefab, transform.position, Quaternion.identity);
                soundInstance.Play();
                Destroy(soundInstance.gameObject, soundInstance.clip.length);
            }

            coinManager.ChangeCoins(value);
            Destroy(gameObject); 
        }
    }
}
