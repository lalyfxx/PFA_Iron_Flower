using UnityEngine;

public class FakeJump : MonoBehaviour
{
    public KeyCode key = KeyCode.Space;
    public float growSpeed = 2f;
    public float shrinkSpeed = 5f;
    public float maxYScale = 2f;
    public float minYScale = 1f;
    public float jumpForce = 5f;

    private Vector3 scale;
    private bool wasAboveMinY = false;
    private Rigidbody2D rbParent;
    private bool isGrounded = false;

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
            if (scale.y > minYScale)
            {
                wasAboveMinY = true;
            }

            scale.y -= shrinkSpeed * Time.deltaTime;

            if (wasAboveMinY && scale.y <= minYScale + 0.01f && isGrounded)
            {
                rbParent.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                wasAboveMinY = false;
            }

            scale.y = Mathf.Max(scale.y, minYScale);
        }

        transform.localScale = scale;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
