using System.Collections;
using System.Collections.Generic;
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
        if (collision.gameObject.CompareTag("LeftBound") && rb.velocity.x < 0f)
        {
            speed *= -1f;
            sprite.flipX = true;
        }
        else if (collision.gameObject.CompareTag("RightBound") && rb.velocity.x > 0f)
        {
            speed *= -1f;
            sprite.flipX = false;
        }
    }
}
