using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ROcketLauncherProjectile : Projectile
{
    [SerializeField]
    private int bounces = 0;
    [SerializeField]
    private float m_Radius;

    protected override void HitSomething(Collision _collision)
    {
        Instantiate(GameManager.Instance.m_Explosion, transform.position, transform.rotation);
        Collider[] col = Physics.OverlapSphere(transform.position,m_Radius);
        foreach (Collider item in col)
        {
            Player player = item.gameObject.GetComponent<Player>();
            if (player)
            {
                player.TakeDamage(1);
            }
            Enemy enemy = item.gameObject.GetComponent<Enemy>();
            if (enemy)
            {
                enemy.TakeDamage(1);
            }
        }
        if (bounces < 1)
        {
            Destroy(this.gameObject);
        }
        bounces--;
    }

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
        Destroy(this.gameObject, Lifetime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HitSomething(collision);
    }
}
