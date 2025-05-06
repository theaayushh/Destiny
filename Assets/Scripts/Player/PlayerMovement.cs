using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // ~~ 1. Controls All Player Movement
    // ~~ 2. Updates Animator to Play Idle & Walking Animations

    public PlayerCombat playerCombat;
    private Rigidbody2D myRigidbody;
    private Vector3 playerMovement;
    private Animator animator;
    private bool isKnockedBack;

    private void Start()
    {
        animator = GetComponent<Animator>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if(Input.GetButtonDown("Attack"))
        {
            playerCombat.Attack();
        }
    }

    private void FixedUpdate()
    {
        if (isKnockedBack == false)
        {
            playerMovement = Vector3.zero;
            playerMovement.x = Input.GetAxisRaw("Horizontal");
            playerMovement.y = Input.GetAxisRaw("Vertical");
            UpdateAnimationAndMove();
        }
    }

    private void UpdateAnimationAndMove()
    {
        if (playerMovement != Vector3.zero)
        {
            MoveCharacter();
            animator.SetFloat("moveX", playerMovement.x);
            animator.SetFloat("moveY", playerMovement.y);
            animator.SetBool("moving", true);
        }
        else
        {
            animator.SetBool("moving", false);
        }
    }

    private void MoveCharacter()
    {
        myRigidbody.MovePosition(transform.position + playerMovement * StatsManager.Instance.speed * Time.deltaTime);
    }

    public void knockBack(Transform enemy, float force, float stunTime)
    {
        isKnockedBack = true;
        Vector2 direction = (transform.position - enemy.position).normalized;
        myRigidbody.linearVelocity = direction * force;
        StartCoroutine(KnockBackCounter(stunTime));
    }

    IEnumerator KnockBackCounter(float duration)
    {
        yield return new WaitForSeconds(duration);
        myRigidbody.linearVelocity = Vector2.zero; // Stop the player from moving
        isKnockedBack = false;
    }
}
