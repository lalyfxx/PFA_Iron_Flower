using UnityEngine;

public class CameraPlaceTrigger : MonoBehaviour
{
    public int zoomPriority = 0;

    public Vector3 offset = new Vector3(0, 5, -10);


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player") == false)
            return;

        var cam = FindAnyObjectByType<CameraFollow2>(FindObjectsInactive.Exclude);
        if (cam != null)
            cam.RegisterTrigger(this);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.attachedRigidbody.CompareTag("Player") == false)
            return;
            
        var cam = FindAnyObjectByType<CameraFollow2>(FindObjectsInactive.Exclude);
        if (cam != null)
            cam.UnregisterTrigger(this);
    }
}
