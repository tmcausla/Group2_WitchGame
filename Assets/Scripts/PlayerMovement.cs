using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;
    public BoxCollider2D coll;
    public Rigidbody2D rb;
    public bool isFlipped;

    [SerializeField] private LayerMask jumpableGround;

    private float movement;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private enum MovementState { idle, running, jumping, shooting }

    
    private void Update()
    {
        movement = Input.GetAxisRaw("Horizontal");

        rb.velocity = new Vector2(movement * speed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && IsGrounded())
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        UpdateAnimation();
    }

    //changes animation based on current type of movement
    private void UpdateAnimation()
    {
        MovementState state;
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (movement < 0f && isFlipped == true)
        {
            state = MovementState.running;
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (movement > 0f && isFlipped == false)
        {
            state = MovementState.running;
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
        }
        else
        {
            state = MovementState.idle;
        }

        if (rb.velocity.y is < (-0.1f) or > 0.1f)
        {
            state = MovementState.jumping;
        }

        anim.SetInteger("state", (int)state);
    }

    //checks if player is in contact with ground
    public bool IsGrounded() => Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
}
