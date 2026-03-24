using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    public Transform player;
    private NavMeshAgent agent;

    public float lives = 6f;

    [Header("Attack")]
    public float attackRange = 2f;
    public float attackCooldown = 1.5f;
    private float lastAttackTime;

    private LivesUI playerLives;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        // Find player's LivesUI
        playerLives = player.GetComponent<LivesUI>();

        // IMPORTANT: stop before reaching player
        agent.stoppingDistance = attackRange;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > attackRange)
        {
            // Chase player
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            // Stop and attack
            agent.isStopped = true;
            TryAttack();
        }
    }

    void TryAttack()
    {
        if (Time.time - lastAttackTime >= attackCooldown)
        {
            // Deal damage
            if (playerLives != null)
            {
                playerLives.TakeDamage(1);
            }

            // Trigger animation
            ZombieAnimation anim = GetComponent<ZombieAnimation>();
            if (anim != null)
            {
                anim.Attack();
            }

            lastAttackTime = Time.time;
        }
    }

    public float GetLives()
    {
        return lives;
    }

    public void LoseLives(float f)
    {
        lives -= f;
    }
}