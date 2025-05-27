using UnityEngine;

public class FakeJump : MonoBehaviour
{
    public static bool IsGrounded { get; private set; } = false;
    public ParticleSystem dust;
    public KeyCode key = KeyCode.Space;
    public float growSpeed = 2f;
    public float shrinkSpeed = 5f;
    public float maxYScale = 2f;
    public float minYScale = 1f;
    public float jumpForce = 5f;
    public Animator animator;

    public AudioSource HittingFloor; 
    public AudioSource LegsGrowing;

    private Vector3 scale;
    private bool wasAboveMinY = false;
    private Rigidbody2D rbParent;

    [Header("Hit")]
    public LayerMask layerCeil;
    public float raycastCeilDistance;
    private bool _isCeilling;

    void Start()
    {
        scale = transform.localScale;
        rbParent = GetComponentInParent<Rigidbody2D>();
    }

    void Update()
    {
        _isCeilling = Physics2D.RaycastAll(transform.position, Vector2.up, raycastCeilDistance, layerCeil).Length != 0;

        Debug.DrawRay(transform.position, Vector2.up * raycastCeilDistance);
        if (_isCeilling)
        {
            if (!Input.GetKey(key))
            {
                scale.y -= shrinkSpeed * Time.deltaTime;

                //RelaseJump();
                scale.y = Mathf.Max(scale.y, minYScale);
                wasAboveMinY = true;

                transform.localScale = scale;
            }

            return;
        }

        scale = transform.localScale;

        if (Input.GetKey(key))
        {
            scale.y += growSpeed * Time.deltaTime;
            scale.y = Mathf.Min(scale.y, maxYScale);
            LegsGrowing.Play();
        }
        else
        {
            scale.y -= shrinkSpeed * Time.deltaTime;

            if (wasAboveMinY && scale.y <= minYScale && IsGrounded)
            {
                RelaseJump();
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

    void RelaseJump()
    {
        Debug.Log("Saut !");
        Vector3 currentVelocity = rbParent.linearVelocity;
        currentVelocity.y = 0;
        rbParent.linearVelocity = currentVelocity;

        if (!_isCeilling)
            rbParent.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

        wasAboveMinY = false;
        IsGrounded = false;
    }

    void EvaluateCollision(ContactPoint2D pointHit)
    {
        CreateDust();
        HittingFloor.Play();
        Debug.Log(pointHit.normal.y);
        if (pointHit.normal.y == 1)
        {
            IsGrounded = true;
        }
    }

    void CreateDust()
    {

        dust.Play();
    }
}


