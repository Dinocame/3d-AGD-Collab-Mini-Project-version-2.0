using UnityEngine;

public class ThreepeaterShooter : PeaShooter
{
    public Transform[] firePoints; // 3 mouths

    protected override void Shoot()
    {
        if (firePoints == null || firePoints.Length == 0)
            return;

        foreach (Transform fp in firePoints)
        {
            GameObject pea = Instantiate(peaPrefab, fp.position, fp.rotation);

            PeaProjectile projectile = pea.GetComponent<PeaProjectile>();
            projectile.damage = damage;
            projectile.slowEnemy = slowEnemy;
            projectile.slowDuration = slowDuration;
            projectile.slowFactor = slowFactor;
        }
    }
}