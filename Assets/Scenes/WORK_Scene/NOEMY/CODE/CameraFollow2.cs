using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CameraFollow2 : MonoBehaviour
{
    public float defaultZoom = 5f;
    public float targetZoom = 5f;

    public HashSet<CameraZoomTrigger> triggerBoxes = new();

    new Camera camera;

    public void RegisterTrigger(CameraZoomTrigger triggerBox)
    {
        triggerBoxes.Add(triggerBox);
    }

    public void UnregisterTrigger(CameraZoomTrigger triggerBox)
    {
        triggerBoxes.Remove(triggerBox);
    }

    void Start()
    {
        camera = GetComponent<Camera>();
    }

    void Update()
    {
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
