using System.Collections;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    private readonly ShootEnemy shootEnemy;
    public float badHealth = 1;
    private readonly float badMaxHealth = 8;
    private readonly int goodDamage = 2;
    private int chance;
    private bool dropRate = false;
    private bool spawn = false;
    private PlaySounds sm;
    public GameObject health;
    public GameObject mana;
    private int itemCount;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private readonly SpriteRenderer spriteRend;

    // Start is called before the first frame update
    private void Start()
    {
        sm = FindObjectOfType<PlaySounds>();
        badHealth = badMaxHealth;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    public void GetHurt(int value)
    {
        
        badHealth = Mathf.Clamp(badHealth - value, 0, badMaxHealth);
        sm.HurtEnemy();
        if (badHealth <= 0)
        {
            Destroy(gameObject);
            dropRate = true;
            DropChance();
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 1; i < 4; i++)
        {
            if (collision.gameObject.CompareTag($"Bullet{i}"))
            {
                GetHurt(goodDamage);
            }
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