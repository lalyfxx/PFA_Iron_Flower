using UnityEngine;

    public class CameraController : MonoBehaviour
{
    public GameObject target;
    public float smoothTime;
    public Vector3 offset;

    private Vector2 _velocity;

    void Start()
    {

    }

    void Update()
    {
        var smoothPos = Vector2.SmoothDamp(transform.position, target.transform.position + offset, ref _velocity, smoothTime);
        Vector3 targetPos = new(smoothPos.x, smoothPos.y, transform.position.z);
        transform.position = targetPos;
    }
}
