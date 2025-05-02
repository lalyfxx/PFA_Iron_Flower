using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; 
    public Vector3 offset = new Vector3(0, 5, -10); 

    void LateUpdate()
    {
        transform.position = target.position + offset;
    }
}
