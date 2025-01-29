using System.Collections;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange; // Range for the attack
    public LayerMask playerLayer; // LayerMask for the player
    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Check for player within attack range
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, attackRange, playerLayer);

        foreach (Collider collider in hitColliders)
        {
            if (collider.CompareTag("Player"))
            {
                Invoke("AttackPlayer", 1f);
            }
        }
    }

    void AttackPlayer()
    {
        //the parameter in my animator will trigger "isAttacking"
        animator.SetTrigger("IsAttacking");
        Debug.Log("I am Attacking");
    }

    private void OnDrawGizmosSelected()
    {
        // Visualize attack range in the Editor
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}