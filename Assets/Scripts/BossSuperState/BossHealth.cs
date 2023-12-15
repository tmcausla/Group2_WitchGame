using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHealth : MonoBehaviour
{
    private PlaySounds sm;
    private Boss boss;
    public Slider bossHealth;

    public int health = 100;
    private int damage = 3;

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

    public void TakeDamage(int damage)
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
    public void TakeDamageBullet(int damage)
    {
            health -= damage;

            if (health <= 0)
            {
                Die();
            }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        for (int i = 1; i < 4; i++)
        {
            if (collision.gameObject.CompareTag($"Bullet{i}"))
            {
                sm.PlayBossHurt();
                TakeDamageBullet(damage);
            }
        }
    }
    void Die()
    {
        sm.PlayBossDeathSound();
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
