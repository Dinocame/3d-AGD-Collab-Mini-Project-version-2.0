using UnityEngine;
using System.Collections;

public class RepeaterShooter : PeaShooter
{
    public int shotsPerTrigger = 2;
    public float timeBetweenShots = 0.2f;

    protected override void Shoot()
    {
        StartCoroutine(FireRepeater());
    }

    private IEnumerator FireRepeater()
    {
        for (int i = 0; i < shotsPerTrigger; i++)
        {
            GameObject pea = Instantiate(peaPrefab, firePoint.position, firePoint.rotation);

            PeaProjectile projectile = pea.GetComponent<PeaProjectile>();
            projectile.damage = damage;
            projectile.slowEnemy = slowEnemy;
            projectile.slowDuration = slowDuration;
            projectile.slowFactor = slowFactor;

            yield return new WaitForSeconds(timeBetweenShots);
        }
    }
}