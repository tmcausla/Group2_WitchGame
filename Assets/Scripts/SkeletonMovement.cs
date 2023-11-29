using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    public GameObject player;
    public Animator anim;

    [SerializeField] private float speed;
    [SerializeField] private float range;

    private void Update()
    {
        CheckRange();

        rb.velocity = new Vector2(speed * (transform.position.x - player.transform.position.x), rb.velocity.y);

        if (rb.velocity.x > 0)
        {
            sprite.flipX = true;
        }
        else if (rb.velocity.x < 0)
        {
            sprite.flipX = false;
        }
    }

    private void CheckRange()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < range)
        {
            anim.SetBool("moving", true);
            speed = -2f;
        }
    }
}
