using UnityEngine;
using static UnityEngine.Rendering.DebugUI;

public class PlayerJump : MonoBehaviour
{
    public float speedJump;

    public GameObject headerGO;
    public GameObject footerGO;

    public GameObject legs;

    private float _tallValue;

    private Rigidbody2D Rigidbody2D;

    private void Awake()
    {
        TryGetComponent(out Rigidbody2D);
    }

    private void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Rigidbody2D.bodyType = RigidbodyType2D.Kinematic;

            _tallValue += Time.deltaTime * speedJump;
            var value = Mathf.Clamp(_tallValue, 0f, 10);

            legs.GetComponent<SpriteRenderer>().size = new(legs.GetComponent<SpriteRenderer>().size.x, value + .5f);
            headerGO.transform.localPosition = new(headerGO.transform.localPosition.x, value, headerGO.transform.localPosition.z);
            footerGO.transform.localPosition = new(0, -.5f, 0);
        }
        else
        {
            if (_tallValue > 0f)
                _tallValue -= Time.deltaTime * speedJump;

            var value = .5f + Mathf.Clamp(_tallValue, 0f, 10);
            legs.GetComponent<SpriteRenderer>().size = new(legs.GetComponent<SpriteRenderer>().size.x, value);
            footerGO.transform.localPosition = new(footerGO.transform.localPosition.x, headerGO.transform.localPosition.y - value, footerGO.transform.localPosition.z);
        }

        if (_tallValue <= 0f)
        {
            transform.position = headerGO.transform.position;
            headerGO.transform.localPosition = Vector2.zero;
            footerGO.transform.localPosition = Vector2.up * -0.5f;
            Rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        }

    }
}
