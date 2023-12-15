using UnityEngine;

public class DamageHealth : MonoBehaviour
{
    public PlayerHealth playerHealth;
    public int damage = 0;
    public bool knockPlayer = false;

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
            return;
        }
        playerHealth.KnockFromRight = false;
    }
}
