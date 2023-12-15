using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private readonly ShootEnemy shootEnemy;
    public float badHealth = 1;
    [SerializeField] private float badMaxHealth = 8;
    private int chance;
    private bool dropRate = false;
    private bool spawn = false;
    public GameObject health;
    public GameObject mana;
    private int itemCount;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private readonly SpriteRenderer spriteRend;

    // Start is called before the first frame update
    private void Start()
    {
        badHealth = badMaxHealth;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void GetHurt(float value)
    {
        badHealth = Mathf.Clamp(badHealth - value, 0, badMaxHealth);
        if (badHealth <= 0)
        {
            Destroy(gameObject);
            dropRate = true;
            DropChance();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            GetHurt(collision.gameObject.GetComponent<Bullet>().damage);
        }

        if (collision.gameObject.CompareTag("Bullet2"))
        {
            GetHurt(collision.gameObject.GetComponent<ShotgunBullet>().damage);
        }
    }

    public void DropChance()
    {
        if (dropRate == true)
        {
            chance = Random.Range(1, 10);
            dropRate = false;
        }

        if (chance == 5)
        {
            spawn = true;
            if (spawn == true && itemCount < 1)
            {
                _ = Instantiate(mana, transform.position, transform.rotation);
                dropRate = false;
                spawn = false;
                itemCount++;
            }
        }
        else if (chance is 7 or 8)
        {
            spawn = true;
            if (spawn == true && itemCount < 1)
            {
                _ = Instantiate(health, transform.position, transform.rotation);
                dropRate = false;
                spawn = false;
                itemCount++;
            }

        }
    }
}