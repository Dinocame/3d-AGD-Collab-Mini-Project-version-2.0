using UnityEngine;
using System.Collections;

public class PeaProjectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 5f;

    // --- Shooter-assigned fields ---
    [HideInInspector] public float damage = 1f;
    [HideInInspector] public bool slowEnemy = false;
    [HideInInspector] public float slowDuration = 2f;
    [HideInInspector] public float slowFactor = 0.5f;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        rb.velocity = transform.forward * speed;

        IgnorePlantAndPlayer();   // <-- added line

        Destroy(gameObject, lifetime);
    }

    void IgnorePlantAndPlayer()
    {
        Collider myCol = GetComponent<Collider>();

        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        GameObject[] plants = GameObject.FindGameObjectsWithTag("Plant");

        foreach (GameObject obj in players)
        {
            Collider[] colliders = obj.GetComponentsInChildren<Collider>();

            foreach (Collider col in colliders)
            {
                Physics.IgnoreCollision(myCol, col);
            }
        }

        foreach (GameObject obj in plants)
        {
            Collider[] colliders = obj.GetComponentsInChildren<Collider>();

            foreach (Collider col in colliders)
            {
                Physics.IgnoreCollision(myCol, col);
            }
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Search for EnemyMovement in self or parents
        EnemyMovement enemy = collision.gameObject.GetComponent<EnemyMovement>();
        if (enemy == null)
            enemy = collision.gameObject.GetComponentInParent<EnemyMovement>();

        if (enemy != null)
        {
            // Apply damage
            enemy.LoseLives(damage);

            // Apply slow if needed
            if (slowEnemy)
            {
                StartCoroutine(SlowEnemy(enemy));
            }

            // Destroy enemy if dead
            if (enemy.GetLives() <= 0)
            {
                Destroy(enemy.gameObject);
            }
        }

        Destroy(gameObject);
    }

    private IEnumerator SlowEnemy(EnemyMovement enemy)
    {
        if (enemy == null) yield break;

        UnityEngine.AI.NavMeshAgent agent = enemy.GetComponent<UnityEngine.AI.NavMeshAgent>();
        if (agent != null)
        {
            float originalSpeed = agent.speed;
            agent.speed *= slowFactor;

            yield return new WaitForSeconds(slowDuration);

            if (agent != null)
                agent.speed = originalSpeed;
        }
    }
}