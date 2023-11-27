using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    ShootEnemy shootEnemy;
    public float badHealth =1;
    private float badMaxHealth = 8;
    private int goodDamage = 2;
    private int chance;
    private bool dropRate = false;
    private bool spawn = false;
    public GameObject health;
    public GameObject mana;
    private int itemCount;
    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriteRend;
    // Start is called before the first frame update
    void Start()
    {
        badHealth = badMaxHealth;
        gameObject.GetComponent<SpriteRenderer>().enabled = true;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void GetHurt(int value)
    {
        StartCoroutine(Invunerability());
        badHealth = Mathf.Clamp(badHealth - value, 0, badMaxHealth);
        if(badHealth <= 0)
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
            GetHurt(goodDamage);
        }
        if (collision.gameObject.CompareTag("Bullet2"))
        {
            GetHurt(goodDamage);
        }
        if (collision.gameObject.CompareTag("Bullet3"))
        {
            GetHurt(goodDamage);
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
                Instantiate(mana, transform.position, transform.rotation);
                dropRate = false;
                spawn = false;
                itemCount++;
            }
        }
        else if (chance == 7 || chance == 8)
        {
            spawn = true;
            if (spawn == true && itemCount < 1)
            {
                Instantiate(health, transform.position, transform.rotation);
                dropRate = false;
                spawn = false;
                itemCount++;
            }

        }
    }
    private IEnumerator Invunerability()
    {
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriteRend.color = new Color(1, 0, 0, 0.5f);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriteRend.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
        }

    }

}
