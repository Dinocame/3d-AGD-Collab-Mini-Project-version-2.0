using UnityEngine;
using UnityEngine.AI;

public class ZombieAnimation : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        // Use desiredVelocity for movement detection
        Vector3 horizontalVelocity = new Vector3(agent.desiredVelocity.x, 0, agent.desiredVelocity.z);

        bool isMoving = horizontalVelocity.magnitude > 0.1f;

        animator.SetBool("isWalking", isMoving);

        // Optional: debug
        // Debug.Log("Horizontal speed: " + horizontalVelocity.magnitude + " | isMoving: " + isMoving);
    }
}