using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    private Animator animator;
    private Player playerControls;

    void Awake()
    {
        animator = GetComponent<Animator>();
        playerControls = GetComponent<Player>();
    }

    void Update()
    {

        if (playerControls.Grounded())
        {
            animator.SetInteger("pMove", playerControls.HoritzontalMove());
            animator.SetBool("pGrounded", playerControls.Grounded());
            animator.SetInteger("pJumpVelocity", playerControls.JumpVelocity());
        }

    }
}
