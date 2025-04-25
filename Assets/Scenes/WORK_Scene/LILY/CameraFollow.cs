using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Ta boule
    public Vector3 offset = new Vector3(0, 5, -10); // Distance caméra-boule

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
