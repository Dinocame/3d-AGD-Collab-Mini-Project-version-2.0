using UnityEngine;
using UnityEngine.AI;

public class ZombieAnimation : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    private bool isAttacking = false; // prevents spam

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (isAttacking) return; // stop walking while attacking

        Vector3 horizontalVelocity = new Vector3(agent.desiredVelocity.x, 0, agent.desiredVelocity.z);
        bool isMoving = horizontalVelocity.magnitude > 0.1f;

        animator.SetBool("isWalking", isMoving);
    }

    public void Attack()
    {
        if (isAttacking) return;

        isAttacking = true;
        animator.SetTrigger("Attack");

        agent.isStopped = true;

        // Reset after attack animation (~1 sec, adjust as needed)
        Invoke(nameof(ResetAttack), 1.0f);
    }

    void ResetAttack()
    {
        isAttacking = false;
        agent.isStopped = false;
    }
}