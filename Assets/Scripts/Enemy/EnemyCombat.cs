using UnityEngine;

public class EnemyCombat : MonoBehaviour
{
    public int damage;
    public Transform attackPoint;
    public float weaponRange;
    public LayerMask playerLayer;
    public float knockBackForce;
    public float stunTime;


    public void Attack()
    {
        Collider2D[] hitPlayers = Physics2D.OverlapCircleAll(attackPoint.position, weaponRange, playerLayer);
        
        if (hitPlayers.Length > 0)
        {
            hitPlayers[0].GetComponent<PlayerHealth>().ChangeHealth(-damage);
            hitPlayers[0].GetComponent<PlayerMovement>().knockBack(transform, knockBackForce, stunTime);
        }
    }
}
