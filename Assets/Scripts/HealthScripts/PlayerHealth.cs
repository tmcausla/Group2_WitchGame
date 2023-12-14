using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float health;
    private readonly float maxHealth = 8;
    private readonly int damage = 1;
    public float KBForce;
    public float KBCounter;
    public float KBTotalTime;
    public bool KnockFromRight;

    [Header("iFrames")]
    [SerializeField] private float healthValue;
    [SerializeField] private AudioSource healthPickup;
    [SerializeField] private AudioSource hurtSound;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    [SerializeField] private AudioSource deathSoundEffect;
    private SpriteRenderer spriteRend;
    public Image[] hearts;
    private readonly DamageHealth damageHealth;

    public Sprite fullHeart;
    public Sprite emptyHeart;

    private Rigidbody2D rb;
    private Animator anim;

    // Start is called before the first frame update
    private void Start()
    {
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
        Physics2D.IgnoreLayerCollision(6, 7, false);
        health = maxHealth;
        {
            rb = GetComponent<Rigidbody2D>();
            anim = GetComponent<Animator>();
            spriteRend = GetComponent<SpriteRenderer>();
        }
    }

    public void TakeDamage(int amount)
    {
        //hurtSound.Play();
        //anim.SetTrigger("hurt");
        _ = StartCoroutine(Invunerability());

        health = Mathf.Clamp(health - amount, 0, maxHealth);
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        gameObject.GetComponent<SpriteRenderer>().enabled = false;
        RestartLevel();

        //anim.SetTrigger("death");
    }

    public void RestartLevel() => SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    // Update is called once per frame
    private void Update()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < maxHealth)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    //private void FixedUpdate()
    //{
    //    if (KBCounter <= 0 && damageHealth.knockPlayer == true)
    //    {
    //        rb.velocity = KnockFromRight == true ? new Vector2(-KBForce, KBForce) : new Vector2(KBForce, KBForce);
    //
    //        KBCounter -= Time.deltaTime;
    //        damageHealth.knockPlayer = false;
    //    }
    //}

    private IEnumerator Invunerability()
    {
        Physics2D.IgnoreLayerCollision(6, 7, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }
        Physics2D.IgnoreLayerCollision(6, 7, false);
    }

    public void AddHealth(float _value) => health = Mathf.Clamp(health + _value, 0, maxHealth);

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            TakeDamage(damage);
        }
        if (collision.gameObject.CompareTag("Laser"))
        {
            TakeDamage(damage);
        }
        if (collision.gameObject.CompareTag("Trap"))
        {
            Die();
        }
    }
}