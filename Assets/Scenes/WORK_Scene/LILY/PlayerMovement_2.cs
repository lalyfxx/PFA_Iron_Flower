using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;              
    public float moveSpeed = 5f;   
    public KeyCode key = KeyCode.Space ; 
    public float scaledY = 2f;
    private Vector3 originalScale ; 

    void Start (){

        originalScale = transform.localScale;

    }
  

    void Update()
    {
        
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        MovePlayer(horizontalMovement);

        if (Input.GetKey(key))
        {
            transform.localScale = new Vector3(originalScale.x, scaledY, originalScale.z);
            print("j'appuie");
        }
        else
        {
            transform.localScale = originalScale;
        }
        

  
    }

    void MovePlayer(float _horizontalMovement)
    {
        
        Vector2 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = targetVelocity;
    }


}
