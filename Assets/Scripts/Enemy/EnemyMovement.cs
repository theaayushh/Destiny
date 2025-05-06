using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float attackRange;
    public float attackCooldown;
    public float playerDetectionRange;
    public Transform detectionPoint;
    public LayerMask playerLayer;

    private float attackTimer;
    private Rigidbody2D rb;
    private Transform player;
    private Vector3 enemyMovement;
    private Animator animator;
    private EnemyState enemyState;


    //Code Starts here
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        ChangeState(EnemyState.Idle);
    }

    //Checks if object entered in the trigger collider is player or not.
    private void CheckForPlayer()
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(detectionPoint.position, playerDetectionRange, playerLayer);
        if (hits.Length > 0)
        {
            player = hits[0].transform;

            if (Vector2.Distance(transform.position, player.transform.position) < attackRange && attackTimer <= 0)
            {
                ChangeState(EnemyState.Attack);
                attackTimer = attackCooldown;
            }

            else if (Vector2.Distance(transform.position, player.position) > attackRange && enemyState != EnemyState.Attack)
            {
                ChangeState(EnemyState.Chase);
            }
        }
        else
        {
            rb.linearVelocity = Vector2.zero; // Stop the enemy when the player exits the trigger
            ChangeState(EnemyState.Idle);
        }
    }
         
    

    //Update enemy per frame
    private void Update()
    {
        if (enemyState != EnemyState.KnockBack)
        {
            CheckForPlayer();

            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }

            if (enemyState == EnemyState.Chase)
            {
                enemyMovement = (player.position - transform.position).normalized;
                Chase();
                UpdateXY();
            }

            else if (enemyState == EnemyState.Attack)
            {
                rb.linearVelocity = Vector2.zero; // Stop the enemy when attacking
            }

            else
            {
                enemyMovement = Vector3.zero;
                UpdateXY();
            }
        }
    }



    //Updat enemy X & Y value for animation
    private void UpdateXY()
    {
        if (enemyMovement != Vector3.zero)
        {
            Chase();
            animator.SetFloat("moveX", enemyMovement.x);
            animator.SetFloat("moveY", enemyMovement.y);
        }
    }

    //Move enemy to the player position
    private void Chase()
    {
       
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed; // Move the enemy towards the player
    }

    //Change the state of the enemy
    public void ChangeState(EnemyState newState)
    {
        //Exit current animation
        if (enemyState == EnemyState.Idle)
            animator.SetBool("Idle", false);
        else if (enemyState == EnemyState.Patrol)
            animator.SetBool("Patrol", false);
        else if (enemyState == EnemyState.Chase)
            animator.SetBool("Chase", false);
        else if (enemyState == EnemyState.Attack)
            animator.SetBool("Attack", false);

        //Update state
        enemyState = newState;

        //Enter new animation
        if (enemyState == EnemyState.Idle)
            animator.SetBool("Idle", true);
        else if (enemyState == EnemyState.Patrol)
            animator.SetBool("Patrol", true);
        else if (enemyState == EnemyState.Chase)
            animator.SetBool("Chase", true);
        else if (enemyState == EnemyState.Attack)
            animator.SetBool("Attack", true);

    }

    //Enum for enemy state
    public enum EnemyState
    {
        Idle,
        Patrol,
        Chase,
        Attack,
        KnockBack
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(detectionPoint.position, playerDetectionRange);
    }
}