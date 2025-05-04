using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    public float attackRange;
    public float attackCooldown;

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
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (player == null)
            {
                player = collision.transform;
            }
            ChangeState(EnemyState.Chase);
        }
    }

    //Update enemy per frame
    private void Update()
    {
        if (attackTimer > 0)
        {
            attackTimer -= Time.deltaTime;
        }

        if (enemyState == EnemyState.Chase && player != null)
        {
            enemyMovement = (player.position - transform.position).normalized;
            MoveCharacter();
            UpdateAnimationAndMove();
        }

        else if (enemyState == EnemyState.Attack)
        {
            rb.linearVelocity = Vector2.zero; // Stop the enemy when attacking
        }

        else
        {
            enemyMovement = Vector3.zero;
            UpdateAnimationAndMove();
        }
    }



    //Updat enemy X & Y value for animation


    private void UpdateAnimationAndMove()
    {
        if (enemyMovement != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", enemyMovement.x);
            animator.SetFloat("moveY", enemyMovement.y);
        }
    }

    //Move enemy to the player position
    private void MoveCharacter()
    {
        if (Vector2.Distance(transform.position, player.position) <= attackRange && attackTimer <= 0)
        {
            attackTimer = attackCooldown;
            ChangeState(EnemyState.Attack);
            animator.SetBool("Attack", true);
            animator.SetBool("Chase", false);
        }
        //rb.MovePosition(transform.position + enemyMovement * speed * Time.deltaTime);
        Vector2 direction = (player.position - transform.position).normalized;
        rb.linearVelocity = direction * speed; // Move the enemy towards the player
    }

    //Checks if object exited the trigger collider is player or not.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.linearVelocity = Vector2.zero; // Stop the enemy when the player exits the trigger
            ChangeState(EnemyState.Idle);
        }
    }

    //Change the state of the enemy
    void ChangeState(EnemyState newState)
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
        Attack
    }
}