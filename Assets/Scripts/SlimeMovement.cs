using UnityEngine;

public class SlimeMovement : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    [SerializeField] private float speed;

    private void Update()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Slime detects boundaries to change direction of movement
        if (rb.velocity.x != 0f)
        {
            speed *= -1f;
            sprite.flipX = collision.gameObject.CompareTag("LeftBound") && rb.velocity.x < 0f ? true : false;
        }
    }
}
