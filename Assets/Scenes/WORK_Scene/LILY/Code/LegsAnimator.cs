using System;
using UnityEngine;

public class LegsAnimator : MonoBehaviour
{
    public Animator animator;

    void FixedUpdate()
    {
        float horizontalMovement = Input.GetAxis("Horizontal");
        animator.SetFloat("speed",Math.Abs(horizontalMovement));
    }
}
