using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public static bool IsTouchingGround { get; private set; } = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
            IsTouchingGround = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
            IsTouchingGround = false;
    }
}
