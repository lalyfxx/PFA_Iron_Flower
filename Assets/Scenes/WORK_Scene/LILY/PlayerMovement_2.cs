using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;              
    public float moveSpeed = 5f;        

  

    void FixedUpdate()
    {
        
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        MovePlayer(horizontalMovement);

        
  
    }

    void MovePlayer(float _horizontalMovement)
    {
        
        Vector2 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = targetVelocity;
    }

    void LegsExtended ()
    {
        

    }

}
