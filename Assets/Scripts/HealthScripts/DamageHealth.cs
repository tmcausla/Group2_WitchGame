using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHealth : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 2;
    public bool knockPlayer = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            playerHealth.TakeDamage(damage);
        }

            
        knockPlayer = true;
        playerHealth.KBCounter = playerHealth.KBTotalTime;
        if (collision.transform.position.x <= transform.position.x)
        {
            playerHealth.KnockFromRight = true;
        }
        if (collision.transform.position.x > transform.position.x)
        {
            playerHealth.KnockFromRight = false;
        }
        
    }
    
}
