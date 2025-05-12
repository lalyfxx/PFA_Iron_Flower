using UnityEngine;

public class GroundSensor : MonoBehaviour
{
    public static bool IsTouchingGround { get; private set; }

    private int groundContacts = 0;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            groundContacts++;
            IsTouchingGround = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            groundContacts--;
            if (groundContacts <= 0)
            {
                IsTouchingGround = false;
                groundContacts = 0;
            }
        }
    }
}
