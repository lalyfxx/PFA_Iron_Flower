using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public Rigidbody2D rb;              // Rigidbody2D des jambes
    public Transform body;              // Le corps du joueur (enfant des jambes)
    public Transform legs;              // Transform des jambes
    public float moveSpeed = 5f;        // Vitesse de déplacement horizontal
    public float stretchSpeed = 2f;     // Vitesse d'extension des jambes
    public float retractSpeed = 6f;     // Vitesse de rétraction des jambes
    public float maxStretchHeight = 3f; // Hauteur maximale d'extension des jambes

    private float currentHeight = 0f;   // Hauteur actuelle des jambes
    private bool isStretching = false;  // Est-ce que la touche 'W' est enfoncée ?

    void FixedUpdate()
    {
        // 1. Déplacement horizontal
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        MovePlayer(horizontalMovement);

        // 2. Extension et rétraction des jambes
        HandleLegStretch();
    }

    void MovePlayer(float _horizontalMovement)
    {
        // Déplacement horizontal avec Rigidbody2D (le Rigidbody des jambes)
        Vector2 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = targetVelocity;
    }

    void HandleLegStretch()
    {
        
        isStretching = Input.GetKey(KeyCode.W);

        if (isStretching)
        {
            currentHeight += stretchSpeed * Time.fixedDeltaTime;
        }
        else
        {
            currentHeight -= retractSpeed * Time.fixedDeltaTime;
        }

        currentHeight = Mathf.Clamp(currentHeight, 0f, maxStretchHeight);

        legs.localPosition = new Vector3(0, -currentHeight / 2f, 0);
        legs.localScale = new Vector3(1, currentHeight, 1);


        body.localPosition = new Vector3(0, currentHeight / 2f, 0); 
    }
}
