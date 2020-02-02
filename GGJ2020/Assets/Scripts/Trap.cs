using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource),typeof(Collider))]
public class Trap : MonoBehaviour
{
    [SerializeField]
    private int m_Damage;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            player.TakeDamage(m_Damage);
        }
        Enemy enemy = other.gameObject.GetComponent<Enemy>();
        if (enemy)
        {
            enemy.TakeDamage(m_Damage);
        }
    }
}
