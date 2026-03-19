using UnityEngine;

public class PeaProjectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 5f;
    public float damage = 1f;       // Default 1 damage
    public bool slowEnemy = false;  // Optional slow effect
    public float slowDuration = 2f; // Seconds
    public float slowFactor = 0.5f; // Halve movement

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = transform.forward * speed;

        Destroy(gameObject, lifetime);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            EnemyMovement enemy = collision.gameObject.GetComponent<EnemyMovement>();
            if (enemy != null)
            {
                enemy.LoseLives(damage);

                if (slowEnemy)
                {
                    StartCoroutine(SlowEnemy(enemy));
                }

                if (enemy.GetLives() <= 0)
                {
                    Destroy(enemy.gameObject);
                }
            }
        }

        Destroy(gameObject);
    }

    private System.Collections.IEnumerator SlowEnemy(EnemyMovement enemy)
    {
        if (enemy == null) yield break;

        UnityEngine.AI.NavMeshAgent agent = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent != null)
        {
            float originalSpeed = agent.speed;
            agent.speed *= slowFactor;
            yield return new WaitForSeconds(slowDuration);
            if (agent != null)
            {
                agent.speed = originalSpeed;
            }
        }
    }
}