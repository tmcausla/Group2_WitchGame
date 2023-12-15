using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    private PlaySounds sm;
    private Boss boss;
    public Slider bossHealth;

    public float health = 60;

    public GameObject deathEffect;

    public bool isInvulnerable = true;

    public void Awake()
    {
        sm = FindObjectOfType<PlaySounds>();
    }

    private void Update()
    {
        bossHealth.value = health;
        
    }

    public void TakeDamage(float damage)
    {
        if (isInvulnerable == false)
        {
            sm.PlayBossHurt();
            health -= damage;

            if (health <= 0)
            {
                Die();
            }
        }
        else
        {
            sm.PlayBossImmuneSound();
        }
     
    }
    public void TakeDamageBullet(float damage)
    {
            health -= damage;

            if (health <= 0)
            {
                Die();
            }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet1"))
        {
            sm.PlayBossHurt();
            TakeDamageBullet(collision.gameObject.GetComponent<Bullet>().damage);
        }

        if (collision.gameObject.CompareTag("Bullet2"))
        {
            sm.PlayBossHurt();
            TakeDamageBullet(collision.gameObject.GetComponent<ShotgunBullet>().damage);
        }
    }
    void Die()
    {
        sm.PlayBossDeathSound();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
