using UnityEditor.Build;
using UnityEngine;

public class FakeJump : MonoBehaviour
{
    public static bool IsGrounded { get; private set; } = false;

    public KeyCode key = KeyCode.Space;
    public float growSpeed = 2f;
    public float shrinkSpeed = 5f;
    public float maxYScale = 2f;
    public float minYScale = 1f;
    public float jumpForce = 5f;

    private Vector3 scale;
    private bool wasAboveMinY = false;

    private Rigidbody2D rbParent;

    void Start()
    {
        scale = transform.localScale;
        rbParent = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        scale = transform.localScale;

        if (Input.GetKey(key))
        {
            scale.y += growSpeed * Time.deltaTime;
            scale.y = Mathf.Min(scale.y, maxYScale);
        }
        else
        {
            scale.y -= shrinkSpeed * Time.deltaTime;
            
            if (wasAboveMinY && scale.y <= minYScale + 0.01f && IsGrounded)
            {
                Debug.Log("Saut !");
                Vector3 currentVelocity = rbParent.linearVelocity;
                currentVelocity.y = 0;
                rbParent.linearVelocity = currentVelocity;
                rbParent.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                wasAboveMinY = false;
                IsGrounded = false;
            }

            scale.y = Mathf.Max(scale.y, minYScale);
        }

        if (Input.GetKeyDown(key))
        {
            wasAboveMinY = true;
        }

        transform.localScale = scale;
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        foreach (var contact in other.contacts)
        {
            EvaluateCollision(contact);
        }
    }

    

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            
        }
    }

    void EvaluateCollision(ContactPoint2D pointHit)
    {
        Debug.Log(pointHit.normal.y);
        if (pointHit.normal.y >= 0.9f)
        {
            IsGrounded = true;
        }

          
       
    }
}
