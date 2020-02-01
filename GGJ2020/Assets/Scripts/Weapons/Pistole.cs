using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistole : Weapon
{
    [SerializeField]
    Projectile m_ProjectilePrefab;

    public override void Shoot()
    {        
        Projectile proj = Instantiate(m_ProjectilePrefab, m_SpawnPointProjectile.position, Quaternion.Euler(0, m_SpawnPointProjectile.rotation.y, 0));
        proj.GetComponent<Rigidbody>().velocity = proj.transform.forward * proj.Speed;
    }
}
