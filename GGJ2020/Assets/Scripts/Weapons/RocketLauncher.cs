using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketLauncher : Weapon
{
    private float m_Interval = 1f;
    private float m_Timer = 0;

    public override void Shoot()
    {
        if (m_Timer > m_Interval)
        {
            m_Timer = 0;
            Projectile proj = Instantiate(m_ProjectilePrefab, m_SpawnPointProjectile.position, transform.rotation);
        }
    }

    private void Update()
    {
        m_Timer += Time.deltaTime;
    }
}
