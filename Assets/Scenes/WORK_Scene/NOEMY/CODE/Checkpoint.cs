using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public BoxCollider2D trigger;
    public Animator _animCheckpoint;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player"))
        {
            RespawnController.Instance.respawnPoint = transform;
            trigger.enabled = false;
        }

        if (collision.attachedRigidbody.CompareTag("Player"))
        {
            _animCheckpoint.Play("Iron_Flower_Aseprite_FINAL_MINI_Chek_Point_Animation_0");
        }
        else
        {
            _animCheckpoint.SetBool("isTouched", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _animCheckpoint.SetBool("isTouched", false);
    }
}
