using UnityEngine;

public class ennemyPatrolVertical : MonoBehaviour
{
    public GameObject pointA;
    public GameObject pointB;
    public float speed = 2f;

    private Rigidbody2D _rb;
    private Animator _animator;
    private Transform _currentPoint;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _currentPoint = pointB.transform;
    }

    void FixedUpdate()
    {
        Patrol();
    }

    void Patrol()
    {
        float direction = _currentPoint.position.y - transform.position.y;

        _rb.linearVelocity = new Vector2(_rb.linearVelocity.x, Mathf.Sign(direction) * speed);

        if (Mathf.Abs(direction) < 0.1f)
        {
            _currentPoint = (_currentPoint == pointA.transform) ? pointB.transform : pointA.transform;
        }
    }
}
