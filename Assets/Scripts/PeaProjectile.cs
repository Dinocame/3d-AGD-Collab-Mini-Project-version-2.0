using UnityEngine;

public class PeaProjectile : MonoBehaviour
{
    public float speed = 20f;
    public float lifetime = 5f;

    public float damage;

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
            EnemyMovement enemy = collision.gameObject.GetComponentInParent<EnemyMovement>();

            if (enemy != null)
            {
                enemy.LoseLives(damage);

                if (enemy.GetLives() <= 0)
                {
                    Destroy(enemy.gameObject);
                }
            }
        }

        Destroy(gameObject);
    }
}