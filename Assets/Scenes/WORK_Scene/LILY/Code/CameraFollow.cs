using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [Header("Target")]
    public Transform target;

    [Header("Follow Offset")]
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothTime = 0.2f;

    [Header("Zoom")]
    public float defaultZoom = 5f;
    public float maxZoomOut = 8f;
    public float zoomInSpeed = 5f;
    public float zoomOutSpeed = 1f;
    public float groundZoomInDuration = 0.3f;

    private Vector3 velocity = Vector3.zero;
    private Camera cam;

    private bool wasGrounded = true;
    private bool isZoomingToDefault = false;
    private float zoomTimer = 0f;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (target == null) return;

        // Smooth follow
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

        // Get stretch factor from vertical scale
        float stretchFactor = Mathf.Clamp01((target.localScale.y - 1f) / (2f - 1f));
        float targetZoom = Mathf.Lerp(defaultZoom, maxZoomOut, stretchFactor);

        // Detect landing using FakeJump.IsGrounded
        bool isGrounded = FakeJump.IsGrounded;

        if (isGrounded && !wasGrounded)
        {
            isZoomingToDefault = true;
            zoomTimer = groundZoomInDuration;
        }

        // Zoom behavior
        if (isZoomingToDefault)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, defaultZoom, Time.deltaTime * zoomInSpeed);
            zoomTimer -= Time.deltaTime;
            if (zoomTimer <= 0f || Mathf.Abs(cam.orthographicSize - defaultZoom) < 0.05f)
            {
                isZoomingToDefault = false;
            }
        }
        else
        {
            float speed = (targetZoom > cam.orthographicSize) ? zoomOutSpeed : zoomInSpeed;
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * speed);
        }

        wasGrounded = isGrounded;
    }
}
