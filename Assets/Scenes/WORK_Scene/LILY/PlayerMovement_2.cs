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
        
        float horizontalMovement = Input.GetAxis("Horizontal") * moveSpeed * Time.fixedDeltaTime;
        MovePlayer(horizontalMovement);

        
        HandleLegStretch();
    }

    void MovePlayer(float _horizontalMovement)
    {
        
        Vector2 targetVelocity = new Vector2(_horizontalMovement, rb.linearVelocity.y);
        rb.linearVelocity = targetVelocity;
    }

    void LegsExtended

}
