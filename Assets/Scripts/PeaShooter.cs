using UnityEngine;

public class PeaShooter : MonoBehaviour
{
    public GameObject peaPrefab;
    public Transform firePoint;
    public float fireCooldown = 1f;

    protected float nextFireTime = 0f;

    protected virtual void Update()
    {
        if (Input.GetMouseButton(0) && Time.time >= nextFireTime)
        {
            Shoot();
            nextFireTime = Time.time + fireCooldown;
        }
    }

    protected virtual void Shoot()
    {
        Instantiate(peaPrefab, firePoint.position, firePoint.rotation);
    }
}