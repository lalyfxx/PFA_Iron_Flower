using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Vector3 offset = new Vector3(0, 5, -10);
    public float smoothTime = 0.2f;

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

        // Suivi lissé
        Vector3 desiredPosition = target.position + offset;
        transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothTime);

        bool isGrounded = FakeJump.IsGrounded;

        // Zoom-out seulement si en l'air
        if (!isGrounded)
        {
            float stretchFactor = Mathf.Clamp01((target.localScale.y - 1f) / (2f - 1f));
            float targetZoom = Mathf.Lerp(defaultZoom, maxZoomOut, stretchFactor);

            if (targetZoom > cam.orthographicSize)
                cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, targetZoom, Time.deltaTime * zoomOutSpeed);
        }

        // Atterrissage détecté
        if (isGrounded && !wasGrounded)
        {
            isZoomingToDefault = true;
            zoomTimer = groundZoomInDuration;
        }

        // Rezoom progressif
        if (isZoomingToDefault)
        {
            cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, defaultZoom, Time.deltaTime * zoomInSpeed);
            zoomTimer -= Time.deltaTime;
            if (zoomTimer <= 0f || Mathf.Abs(cam.orthographicSize - defaultZoom) < 0.05f)
            {
                isZoomingToDefault = false;
                cam.orthographicSize = defaultZoom; // lock final
            }
        }

        wasGrounded = isGrounded;
    }
}
