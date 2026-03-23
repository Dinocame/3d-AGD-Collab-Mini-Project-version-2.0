using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    public GameObject peaPrefab;
    public Transform firePoint;

    public float fireCooldown = 1f;
    public float damage = 1f;

    private float nextFireTime = 0f;

    void Update()
    {
        if (transform.parent == null) return;

        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    void Shoot()
    {
        GameObject pea = Instantiate(peaPrefab, firePoint.position, firePoint.rotation);

        PeaProjectile projectile = pea.GetComponent<PeaProjectile>();
        projectile.damage = damage;
    }
}