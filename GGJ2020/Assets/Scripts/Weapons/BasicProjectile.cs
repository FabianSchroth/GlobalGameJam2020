using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : Projectile
{
    protected override void HitSomething(Collision _collision)
    {
        Enemy enemy =_collision.gameObject.GetComponent<Enemy>();
        Player player = _collision.gameObject.GetComponent<Player>();
        if (enemy)
        {
            enemy.TakeDamage(1);
        }
        else if (player)
        {
            player.TakeDamage(1);
        }
        Destroy(this.gameObject);
    }

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * Speed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        HitSomething(collision);
    }
}
