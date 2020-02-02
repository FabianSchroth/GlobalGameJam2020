using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public abstract class Enemy : MonoBehaviour
{

    #region Members / Properties / Constants

    public EnemySpawner Spawner { get; set; }

    protected NavMeshAgent m_Agent;

    public int RemainingHealth { get; set; }
    public int Damage { get; set; }

    #endregion

    #region Functions

    protected void Awake()
    {
        m_Agent = GetComponent<NavMeshAgent>();

        RemainingHealth = 2;
    }

    /// <summary>
    /// Called when the Enemy is taking damage
    /// </summary>
    /// <param name="_amount">The amount of damage to take</param>
    public void TakeDamage(int _amount)
    {
        RemainingHealth -= _amount;

        if (RemainingHealth <= 0)
        {
            //Spawner.OnEnemyKilled();
            Destroy(this.gameObject);
        }
    }

    #endregion
}
