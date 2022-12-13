using UnityEngine;

// This script is a basic 2D character controller that allows
// the player to run and jump. It uses Unity's new input system,
// which needs to be set up accordingly for directional movement
// and jumping buttons.

[RequireComponent(typeof(BoxCollider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    
    [Header("Movement Params")]
    private Animator anim;
    public float runSpeed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravityScale = 20.0f;

    // components attached to player
    private BoxCollider2D coll;
    private Rigidbody2D rb;
    private bool isFacingRight = true;
   
    private bool isGrounded = false;

    private void Awake()
    {
        coll = GetComponent<BoxCollider2D>(); //get reference to box collider component from game obj
        rb = GetComponent<Rigidbody2D>();//get reference to rigid body component from game obj
        rb.gravityScale = gravityScale;
        anim =GetComponent<Animator>(); //get reference to animator component from game obj

    }

    private void FixedUpdate()
    {
        if(DialogueManager.GetInstance().dialogueIsPlaying){
            return;
        }
        UpdateIsGrounded();

        HandleHorizontalMovement();

        HandleJumping();

        anim.SetBool("move", PlayerController.GetInstance().GetMoveDirection().x != 0); 
    }

    private void UpdateIsGrounded()
    {
        Bounds colliderBounds = coll.bounds;
        float colliderRadius = coll.size.x * 0.4f * Mathf.Abs(transform.localScale.x);
        Vector3 groundCheckPos = colliderBounds.min + new Vector3(colliderBounds.size.x * 0.5f, colliderRadius * 0.9f, 0);
        // Check if player is grounded
        Collider2D[] colliders = Physics2D.OverlapCircleAll(groundCheckPos, colliderRadius);
        // Check if any of the overlapping colliders are not player collider, if so, set isGrounded to true
        this.isGrounded = false;
        if (colliders.Length > 0)
        {
            for (int i = 0; i < colliders.Length; i++)
            {
                if (colliders[i] != coll)
                {
                    this.isGrounded = true;
                    break;
                }
            }
        }
    }
    private void Flip(){

            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *=-1f;
            transform.localScale = localScale;
    }

    private void HandleHorizontalMovement()
    {
        Vector2 moveDirection = PlayerController.GetInstance().GetMoveDirection();
        
        if(!isFacingRight && moveDirection.x > 0f){
            Flip();
        }
        else if(isFacingRight && moveDirection.x < 0f){
            Flip();
        }
        rb.velocity = new Vector2(moveDirection.x * runSpeed, rb.velocity.y);
    }

    private void HandleJumping()
    {
        bool jumpPressed = PlayerController.GetInstance().GetJumpPressed();
        if (isGrounded && jumpPressed)
        {
            isGrounded = false;
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

}