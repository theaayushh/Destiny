using System.Collections;
using UnityEngine;

public class EnemyKnockBack : MonoBehaviour
{
    private Rigidbody2D rb;
    private EnemyMovement enemyMovement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemyMovement = GetComponent<EnemyMovement>();
    }
    public void KnockBack(Transform playerTransform, float knockBackForce,float knockbackTime, float stunTime)
    {
        enemyMovement.ChangeState(EnemyMovement.EnemyState.KnockBack);
        StartCoroutine(Stun(knockbackTime,stunTime));
        Vector2 direction = (transform.position - playerTransform.position).normalized;
        rb.linearVelocity = direction * knockBackForce;
    }

    IEnumerator Stun(float knockbackTIme, float stunTime)
    {
        yield return new WaitForSeconds(knockbackTIme);
        rb.linearVelocity = Vector2.zero;
        yield return new WaitForSeconds(stunTime);
        enemyMovement.ChangeState(EnemyMovement.EnemyState.Idle);
    }
}
