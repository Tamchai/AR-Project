using UnityEngine;

public class MonsterHP : MonoBehaviour
{
    public int maxHP = 10;

    private int hp;
    private bool isDead;

    private Animator animator;
    private MonsterAI ai;

    void Start()
    {
        hp = maxHP;

        animator = GetComponent<Animator>();
        ai = GetComponent<MonsterAI>();
    }

    public void TakeDamage(int dmg)
    {
        if (isDead) return;

        hp -= dmg;

        Debug.Log(gameObject.name + " HP: " + hp);

        if (hp <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        isDead = true;

        Debug.Log(gameObject.name + " DEAD");

        if (animator != null)
            animator.SetTrigger("die");

        if (ai != null)
            ai.SetDead();

        Collider col = GetComponent<Collider>();
        if (col != null)
            col.enabled = false;

        Destroy(gameObject, 3f);
    }
}