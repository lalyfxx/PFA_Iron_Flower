using UnityEngine;

public class FakeJump : MonoBehaviour
{
    public KeyCode key = KeyCode.Space;
    public float growSpeed = 0.1f; // Combien d'unités par seconde
    public float maxYScale = 2f;
    public float minYScale = 1f;

    private Vector3 scale;

    void Start()
    {
        scale = transform.localScale;
    }

    void Update()
    {
        scale = transform.localScale; // On part du scale actuel

        if (Input.GetKey(key))
        {
            // On augmente progressivement sur Y
            scale.y += growSpeed * Time.deltaTime;
            scale.y = Mathf.Min(scale.y, maxYScale); // Limite haute
        }
        else
        {
            // On diminue progressivement sur Y
            scale.y -= growSpeed * Time.deltaTime;
            scale.y = Mathf.Max(scale.y, minYScale); // Limite basse
        }

        transform.localScale = scale;
    }
}
