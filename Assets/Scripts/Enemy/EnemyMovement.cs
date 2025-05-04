using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    private bool isChasing;
    private Rigidbody2D rb;
    private Transform player;
    private Vector3 enemyMovement;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    //void Update()
    //{
    //    if (isChasing == true)
    //    {
    //        Vector2 direction = (player.position - transform.position).normalized;
    //        rb.linearVelocity = direction * speed;
    //    }
    //}

    private void FixedUpdate()
    {
        if (isChasing && player != null)
        {
            enemyMovement = (player.position - transform.position).normalized;
            MoveCharacter();
            UpdateAnimationAndMove();
        }
        else
        {
            enemyMovement = Vector3.zero;
            UpdateAnimationAndMove();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(player == null)
            {
                player = collision.transform;
            }
            isChasing = true;
        }
    }

    private void UpdateAnimationAndMove()
    {
        if (enemyMovement != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", enemyMovement.x);
            animator.SetFloat("moveY", enemyMovement.y);
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            rb.linearVelocity = Vector2.zero; // Stop the enemy when the player exits the trigger
            isChasing = false;
        }
    }

    private void MoveCharacter()
    {
        rb.MovePosition(transform.position + enemyMovement * speed * Time.deltaTime);
    }
}   