using UnityEngine;

public class MonsterAI : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float attackRange = 1.5f;
    public float attackCooldown = 1.2f;

    private Transform player;
    private Animator animator;

    private float attackTimer;
    private bool isDead;

    void Start()
    {
        GameObject p = GameObject.FindGameObjectWithTag("Player");
        if (p != null) player = p.transform;

        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (player == null) return;
        if (animator == null) return;
        if (isDead) return;

        attackTimer -= Time.deltaTime;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            MoveToPlayer();
        }
        else
        {
            AttackPlayer();
        }
    }

    void MoveToPlayer()
    {
        transform.LookAt(player);
        transform.Translate(Vector3.forward * moveSpeed * Time.deltaTime);

        animator.SetBool("isWalking", true);
    }

    void AttackPlayer()
    {
        animator.SetBool("isWalking", false);

        if (attackTimer <= 0f)
        {
            animator.SetTrigger("attack");
            attackTimer = attackCooldown;
        }
    }

    public void SetDead()
    {
        isDead = true;
        animator.SetBool("isWalking", false);
    }
}