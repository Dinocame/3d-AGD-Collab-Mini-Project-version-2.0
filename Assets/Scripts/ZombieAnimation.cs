using UnityEngine;
using UnityEngine.AI; // Make sure to include this

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
        // Get the horizontal speed of the agent
        Vector3 horizontalVelocity = new Vector3(agent.velocity.x, 0, agent.velocity.z);

        // If moving, play walking animation
        animator.SetBool("isWalking", horizontalVelocity.magnitude > 0.1f);
    }
}