using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public LayerMask bossLayers;
    public LayerMask redSlime;
    public LayerMask blueSlime;

    public float attackRange = 0.5f;
    public int attackDamage = 2;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Attack();
                anim.SetTrigger("Attack");
                nextAttackTime = Time.time + (1 / attackRate);
            }
        }
    }

    private void Attack()
    {
        
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        foreach (Collider2D enemyCollider2D in hitEnemies)
        {
            enemyCollider2D.GetComponent<EnemyHealth>().GetHurt(attackDamage);
            
        }
        Collider2D[] hitBoss = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, bossLayers);
        foreach (Collider2D enemyCollider2D in hitBoss)
        {
            enemyCollider2D.GetComponent<BossHealth>().TakeDamage(attackDamage);

        }
        Collider2D[] hitRedSlime = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, redSlime);
        foreach (Collider2D enemyCollider2D in hitRedSlime)
        {
            enemyCollider2D.GetComponent<SlimeHealth>().GetHurt(attackDamage);

        }
        Collider2D[] hitBlueSlime = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, blueSlime);
        foreach (Collider2D enemyCollider2D in hitBlueSlime)
        {
            enemyCollider2D.GetComponent<IceSlimeHealth>().GetHurt(attackDamage);

        }

    }

    private void OnDrawGizmosSelected() => Gizmos.DrawWireSphere(attackPoint.position, attackRange);
}