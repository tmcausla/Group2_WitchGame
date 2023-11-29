using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public LayerMask enemyLayers;

    public float attackRange = 0.5f;
    public int attackDamage = 2;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    // Update is called once per frame
    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Attack();
                nextAttackTime = Time.time + (1 / attackRate);
            }
        }
    }

    private void Attack()
    {
        anim.SetTrigger("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemyCollider2D in hitEnemies)
        {
            enemyCollider2D.GetComponent<EnemyHealth>().GetHurt(attackDamage);
        }
    }

    private void OnDrawGizmosSelected() => Gizmos.DrawWireSphere(attackPoint.position, attackRange);
}