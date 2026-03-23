using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    public GameObject peaPrefab;
    public Transform firePoint;

    public float fireCooldown = 1f;
    public float damage = 1f;
    public bool slowEnemy = false;
    public float slowDuration = 2f;
    public float slowFactor = 0.5f;

    protected float nextFireTime = 0f;

    void Update()
    {
        if (transform.parent == null) return; // only fire if held

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    // Make this virtual so it can be overridden
    protected virtual void Shoot()
    {
        GameObject pea = Instantiate(peaPrefab, firePoint.position, firePoint.rotation);

        PeaProjectile projectile = pea.GetComponent<PeaProjectile>();
        projectile.damage = damage;
        projectile.slowEnemy = slowEnemy;
        projectile.slowDuration = slowDuration;
        projectile.slowFactor = slowFactor;
    }
}