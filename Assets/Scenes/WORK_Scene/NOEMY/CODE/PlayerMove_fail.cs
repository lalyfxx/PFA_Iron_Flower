//using UnityEditor.Experimental.GraphView;
//using UnityEngine;

//public class PlayerMove : MonoBehaviour
//{
    //[SerializeField] private Rigidbody2D rb;
  //  [SerializeField] private float jumpForce = 10f;
//    [SerializeField] private LayerMask groundLayer;
    //[SerializeField] private Transform feetPos;
  //  [SerializeField] private float groundDistance = 0.25f;
//    [SerializeField] private float jumpTime = 0.3f;

    //private bool isGrounded = false;
    //private bool isJumping = false;
    //private float jumpTimer;

    //private void Update()
    //{
        //isGrounded = Physics2D.OverlapCircle(feetPos.position, groundDistance, groundLayer);

        //if (isGrounded && Input.GetButtonDown("Jump"))
        //{
            //isJumping = true;
          //  rb.angularVelocity = Vector2.up * jumpForce;
        //}
        //r
        //if (isJumping && Input.GetButton("Jump"))
        //{
            //if (jumpTimer < jumpTime)
            //{
                //rb.angularVelocity = Vector2.up * jumpForce;

              //  jumpTimer += Time.deltaTime;
            //}
            //else
            //{
            //    isJumping = false;
          //  }
        //}
        //if (Input.GetButtonUp("Jump"))
        //{
          //  isJumping = false;
        //    jumpTimer = 0;
      //  }
    //}
  //  }
