using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothTime = 0.2f;
    public float minY = 0f;
    public float maxY = 5f;
    public float defaultZoom = 5f;
    public float maxZoomOut = 8f;

    public float zoomInSpeed = 2f;  
    public float zoomOutSpeed = 1f; 

    private Vector3 velocity = Vector3.zero;
    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        Vector3 targetPosition = target.position + offset;
        targetPosition.y = Mathf.Clamp(targetPosition.y, minY + offset.y, maxY + offset.y);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);

        float stretchFactor = Mathf.Clamp01((target.localScale.y - 1f) / (2f - 1f)); 

        float targetZoom = Mathf.Lerp(defaultZoom, maxZoomOut, stretchFactor);

        if (targetZoom > cam.orthographicSize) 
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomInSpeed);
        }
        else 
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomOutSpeed);
        }
    }
}
