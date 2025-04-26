using UnityEngine;

public class FakeJump : MonoBehaviour
{
    public KeyCode key = KeyCode.Space;
    public float growSpeed = 2f; // Vitesse de montée (unités/sec)
    public float shrinkSpeed = 5f; // Vitesse de descente (unités/sec)
    public float maxYScale = 2f;
    public float minYScale = 1f;

    private Vector3 scale;

    void Start()
    {
        scale = transform.localScale;
    }

    void Update()
    {
        scale = transform.localScale;

        if (Input.GetKey(key))
        {
            // On augmente progressivement sur Y
            scale.y += growSpeed * Time.deltaTime;
            scale.y = Mathf.Min(scale.y, maxYScale);
        }
        else
        {
            // On diminue plus rapidement (ou lentement selon shrinkSpeed)
            scale.y -= shrinkSpeed * Time.deltaTime;
            scale.y = Mathf.Max(scale.y, minYScale);
        }

        transform.localScale = scale;
    }
}
