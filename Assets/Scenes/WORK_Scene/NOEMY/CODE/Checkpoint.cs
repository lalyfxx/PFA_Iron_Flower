using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public BoxCollider2D trigger;
    public Animator _animCheckpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player"))
        {
            Debug.Log("Hello");
            RespawnController.Instance.respawnPoint = transform;
            trigger.enabled = false;
            FindAnyObjectByType<PlayerUI>().lastCheckpointPos = transform.position;
        }

        if (collision.attachedRigidbody.CompareTag("Player"))
        {
            _animCheckpoint.SetBool("IsTouched", true);
        }
    }
}
