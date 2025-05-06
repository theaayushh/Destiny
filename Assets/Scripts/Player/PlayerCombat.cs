using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public Transform attackpoint;
    public LayerMask enemyLayer;
    public Animator animator;
    public float cooldown;
    private float cooldownTimer;



    private void Update()
    {
        if (cooldownTimer > 0)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        if (cooldownTimer <= 0)
        {
            animator.SetBool("Attack", true);
            cooldownTimer = cooldown;
        }
    }

    public void DealDamage()
    {
        Collider2D[] enemies = Physics2D.OverlapCircleAll(attackpoint.position, StatsManager.Instance.weaponRange, enemyLayer);

        if (enemies.Length > 0)
        {
            enemies[0].GetComponent<EnemyHealth>().ChangeHealth(-StatsManager.Instance.damage);
            enemies[0].GetComponent<EnemyKnockBack>().KnockBack(transform, StatsManager.Instance.knockbackForce, StatsManager.Instance.knockbackTime ,StatsManager.Instance.stunTime);
        }
    }

    public void FinishAttack()
    {
        animator.SetBool("Attack", false);
    }

    private void OnDrawGizmosSelected()
    {
        if (attackpoint != null && StatsManager.Instance != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackpoint.position, StatsManager.Instance.weaponRange);
        }
    }

}
