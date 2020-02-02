using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LMG : Weapon
{
    

    public override void Shoot()
    {
        Projectile proj = Instantiate(m_ProjectilePrefab, m_SpawnPointProjectile.position, transform.rotation);
        StartCoroutine(DelayedShot());
    }

    IEnumerator DelayedShot()
    {
        yield return new WaitForSeconds(0.1f);
        Projectile proj = Instantiate(m_ProjectilePrefab, m_SpawnPointProjectile.position, transform.rotation);
    }
}
