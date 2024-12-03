using UnityEngine;

public class SkeletonMovement : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Rigidbody2D rb;
    private GameObject player;
    public Animator anim;

    [SerializeField] private float speed;
    [SerializeField] private float range;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    private void Update()
    {
        CheckRange();

        rb.velocity = new Vector2(speed * (transform.position.x - player.transform.position.x), rb.velocity.y);

        sprite.flipX = rb.velocity.x > 0;
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
