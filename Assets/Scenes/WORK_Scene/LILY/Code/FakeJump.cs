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
    private float groundGraceTime = 0.2f; // délai de tolérance après avoir quitté le sol
    private float lastTimeOnGround;


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
        if (scale.y > minYScale + 0.01f)
        {
            wasAboveMinY = true;
        }

        scale.y -= shrinkSpeed * Time.deltaTime;

        bool canJump = Time.time - lastTimeOnGround <= groundGraceTime;

        if (wasAboveMinY && scale.y <= minYScale + 0.01f && canJump)
        {
            if (rbParent != null)
            {
                rbParent.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                Debug.Log("Jump triggered!");
            }

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
        lastTimeOnGround = Time.time;
    }
}

void OnTriggerExit2D(Collider2D collision)
{
    if (collision.CompareTag("Ground"))
    {
        isGrounded = false;
        lastTimeOnGround = Time.time; // important aussi ici
    }
}

}
