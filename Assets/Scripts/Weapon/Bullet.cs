using UnityEngine;

public class Bullet : MonoBehaviour
{
    public GameObject Effect;
    public ParticleSystem ParticleEffect;
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    private readonly float projectileLife = 5f;
    private float projectileCount;
    public float damage;

    private void Start()
    {
        projectileCount = projectileLife;

        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 180);

        Physics2D.IgnoreLayerCollision(6, 8, true);
        Physics2D.IgnoreLayerCollision(8, 8, true);

    }

    private void Update()
    {
        projectileCount -= Time.deltaTime;
        if (projectileCount <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        var copy = Instantiate(Effect, transform.position, transform.rotation);
        ParticleEffect.Play();
        Destroy(gameObject);
        Destroy(copy);
    }
}