using UnityEngine;

public class ShootEnemy : MonoBehaviour
{
    public EnemyHealth enemyHealth;
    public int goodDamage = 2;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemyHealth.GetHurt(goodDamage);
        }
    }
}
