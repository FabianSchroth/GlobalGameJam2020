using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy01 : Enemy
{
    [SerializeField]
    float m_Range = 0.5f;

    [SerializeField]
    Projectile m_Projectile;

    [SerializeField]
    Transform m_BulletSpawn;

    [SerializeField]
    Transform m_Gun;

    Transform m_Target;

    private float m_Timer = 0;

    [SerializeField]
    private float m_Interval = 1f;

    public AudioSource m_ShootSound;

    private void Start()
    {
        m_Target = GameManager.Instance.m_Player.transform;
    }

    private void Shoot()
    {
        m_Timer = 0;
        m_ShootSound.Play();
        Instantiate(m_Projectile, m_BulletSpawn.position, m_BulletSpawn.rotation);
    }

    private void Update()
    {
        m_Gun.LookAt(m_Target.position);

        m_Timer += Time.deltaTime;
        RaycastHit hit;        
        if (m_Timer >= m_Interval && Physics.Raycast(transform.position + Vector3.up, m_Target.position - transform.position, out hit, m_Range))
        {
            if (hit.collider.gameObject.tag == "Player")
            {
                m_Agent.isStopped = true;
                Shoot();
            }
        }                
        else
        {
            m_Agent.isStopped = false;
            m_Agent.SetDestination(m_Target.position);
        }        
    }
}
