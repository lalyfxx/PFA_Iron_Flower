using UnityEngine;

public class PlayerMovment_2 : MonoBehaviour
{
    public float moveSpeed = 5f; // Mets une valeur par défaut pour tester

    public Rigidbody2D rb;
    private Vector2 velocity = Vector2.zero;

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed;

        MovePlayer(horizontalMovement);
    }

    void MovePlayer(float _horizontalMovement)
    {
        Vector2 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = Vector2.SmoothDamp(rb.linearVelocity, targetVelocity, ref velocity, 0.05f);
    }
}
