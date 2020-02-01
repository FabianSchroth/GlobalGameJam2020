using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistole : Weapon
{
    public override void Shoot()
    {        
        Projectile proj = Instantiate(m_ProjectilePrefab, m_SpawnPointProjectile.position, transform.rotation); 
    }
}
