using UnityEngine;

public class enemyPatrol : MonoBehaviour
{
    public int damage;
    public GameObject pointA;
    public GameObject pointB;
    private Rigidbody2D _rb;
    private Animator _animator;
    private Transform currentPoint;
    public float speed;
    private SpriteRenderer _sprite;



    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _sprite = GetComponent<SpriteRenderer>();
        currentPoint = pointB.transform;
        _animator.SetBool("isMoving", true);
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 point = currentPoint.position - transform.position;

        if (currentPoint == pointB.transform)
        {
            _sprite.flipX = true;
            _rb.linearVelocity = new Vector2(speed, 0);
        }
        else
        {
            _sprite.flipX = false;
            _rb.linearVelocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            currentPoint = pointA.transform;
        }


        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            currentPoint = pointB.transform;
        }


    }



    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }

}