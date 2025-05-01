using UnityEngine;

public class Jump : MonoBehaviour
{
    public KeyCode key = KeyCode.Space;
    public float growSpeed = 2f;
    public float shrinkSpeed = 5f;
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

            scale.y += growSpeed * Time.deltaTime;
            scale.y = Mathf.Min(scale.y, maxYScale);
        }
        else
        {

            scale.y -= shrinkSpeed * Time.deltaTime;
            scale.y = Mathf.Max(scale.y, minYScale);
        }

        transform.localScale = scale;
    }
}
