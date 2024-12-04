using UnityEngine;

public class MeleeCombat : MonoBehaviour
{
    public Animator anim;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public LayerMask bossLayers;
    public LayerMask redSlime;
    public LayerMask blueSlime;
    public BossHealth bossHealth;
    public float attackRange = 0.5f;
    public int attackDamage = 2;
    public float attackRate = 2f;
    private float nextAttackTime = 0f;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }

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
        LayerMask combinedLayers = enemyLayers | bossLayers | redSlime | blueSlime;
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, combinedLayers);
        
        foreach (Collider2D collider in hitColliders)
        {
            // Check if the collider has a Health component and deal damage accordingly
            if (collider.TryGetComponent(out EnemyHealth enemyHealth))
            {
                enemyHealth.GetHurt(attackDamage);
            }
            else if (collider.TryGetComponent(out BossHealth bossHealth))
            {
                bossHealth.TakeDamage(attackDamage);
            }
            else if (collider.TryGetComponent(out SlimeHealth slimeHealth))
            {
                slimeHealth.GetHurt(attackDamage);
            }
            else if (collider.TryGetComponent(out IceSlimeHealth iceSlimeHealth))
            {
                iceSlimeHealth.GetHurt(attackDamage);
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}