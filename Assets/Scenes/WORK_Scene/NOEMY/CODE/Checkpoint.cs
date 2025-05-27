using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public BoxCollider2D trigger;
    public Animator _animCheckpoint;

    public AudioSource checkpoint;

    public ParticleSystem paillettes;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player"))
        {
            RespawnController.Instance.respawnPoint = transform;
            trigger.enabled = false;
            FindAnyObjectByType<PlayerUI>().lastCheckpointPos = transform.position;
        }

        if (collision.attachedRigidbody.CompareTag("Player"))
        {
            _animCheckpoint.SetBool("IsTouched", true);
        }

        if (checkpoint != null)
        {
            checkpoint.Play();
            paillettes.Play();
        }
    }
}
