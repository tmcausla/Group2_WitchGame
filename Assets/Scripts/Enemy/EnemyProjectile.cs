using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage;
    private GameObject target;
    public float speed;
    private Rigidbody2D bulletRB;

    // Start is called before the first frame update
    private void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
        Physics2D.IgnoreLayerCollision(7, 7, true);

        bulletRB = GetComponent<Rigidbody2D>();
        target = GameObject.FindGameObjectWithTag("Player");
        Vector2 moveDir = (target.transform.position - transform.position).normalized * speed;
        Vector2 rotation = transform.position - target.transform.position;
        bulletRB.velocity = new Vector2(moveDir.x, moveDir.y);
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot);
        Destroy(gameObject, 5);
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
