﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicProjectile : Projectile
{
    [SerializeField]
    private int bounces = 0;

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
