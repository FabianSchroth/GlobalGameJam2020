using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    [SerializeField]
    private int m_ProjectileCount = 4;

    public override void Shoot()
    {
        for (int i = 0; i < m_ProjectileCount; i++)
        {
            Projectile proj = Instantiate(m_ProjectilePrefab, m_SpawnPointProjectile.position, Quaternion.LookRotation(transform.forward + transform.right * Random.Range(-0.5f,0.5f)));
        }
    }
}
