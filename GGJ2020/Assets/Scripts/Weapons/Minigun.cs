using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Minigun : Weapon
{
    private bool shoot = false;

    [SerializeField]
    AudioSource source;

    [SerializeField]
    AudioClip clip;

    [SerializeField]
    float m_ShotsPerSec = 10;

    float timer = 0;

    public override void Shoot()
    {
        shoot = !shoot;
    }

    private void Update()
    {
        if (shoot)
        {
            timer += Time.deltaTime;

            if (timer >= (1 / m_ShotsPerSec))
            {
                source.PlayOneShot(clip);
                Projectile proj = Instantiate(m_ProjectilePrefab, m_SpawnPointProjectile.position, transform.rotation);
            }
        }
    }
}
