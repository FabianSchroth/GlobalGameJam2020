using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_02 : Enemy
{
    [SerializeField]
    float m_Range = 0.5f;

    Transform m_Target;
    private void Start()
    {
        m_Target = GameManager.Instance.m_Player.transform;
        m_Agent.SetDestination(m_Target.position);
    }

    private void Update()
    {
        if (m_Agent.remainingDistance <= 1 && !m_Agent.pathPending)
        {
            if ((transform.position - m_Target.position).sqrMagnitude < m_Range * m_Range)
            {
                GameManager.Instance.m_Player.TakeDamage(1);
            }
            m_Agent.SetDestination(m_Target.position);            
        }        
    }
}
