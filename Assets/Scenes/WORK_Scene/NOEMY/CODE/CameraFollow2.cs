using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public float defaultZoom = 5f;
    public Transform target;
    public Vector3 offset = new Vector3(0f, 0f, -10f); // Pour caméra 2D, Z = -10 est standard
    public float smoothSpeed = 5f;
    public float targetZoom = 5f;

    public HashSet<CameraPlaceTrigger> triggerBoxes = new();

    new Camera camera;

    public void RegisterTrigger(CameraPlaceTrigger triggerBox)
    {
        triggerBoxes.Add(triggerBox);
    }

    public void UnregisterTrigger(CameraPlaceTrigger triggerBox)
    {
        triggerBoxes.Remove(triggerBox);
    }

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void FixedUpdate()
    {
        if (target != null)
        {
            Vector3 desiredPosition = target.position + offset;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
            transform.position = smoothedPosition;
        }

        var currentTriggerBox = triggerBoxes
            .OrderBy(t => t.zoomPriority)
            .LastOrDefault();

        if (currentTriggerBox != null)
        {
            targetZoom = currentTriggerBox.zoom;
        }
        else
        {
            targetZoom = defaultZoom;
        }

        camera.orthographicSize = Mathf.Lerp(camera.orthographicSize, targetZoom, 0.1f);
    }
}
