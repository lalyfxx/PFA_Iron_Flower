using UnityEngine;

public class EnemyPatrol2 : MonoBehaviour
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
        float direction = _currentPoint.position.x - transform.position.x;

        _rb.linearVelocity = new Vector2(Mathf.Sign(direction) * speed, _rb.linearVelocity.y);

        if (direction > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);

        if (Mathf.Abs(direction) < 0.1f)
        {
            _currentPoint = (_currentPoint == pointA.transform) ? pointB.transform : pointA.transform;
        }
    }


}
