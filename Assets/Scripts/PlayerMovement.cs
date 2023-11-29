using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Animator anim;
    public SpriteRenderer sprite;
    public BoxCollider2D coll;
    public Rigidbody2D rb;

    [SerializeField] private LayerMask jumpableGround;

    private float movement;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;

    private enum MovementState { idle, running, jumping, shooting }

    // Update is called once per frame
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

    private void UpdateAnimation()
    {
        MovementState state;

        if (movement > 0f)
        {
            state = MovementState.running;
            sprite.flipX = true;
        }
        else if (movement < 0f)
        {
            state = MovementState.running;
            sprite.flipX = false;
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

    public bool IsGrounded() => Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, 0.1f, jumpableGround);
}
