using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{

    #region Members / Properties / Constants

    EnemySpawner Spawner { get; set; }

    public int RemainingHealth { get; set; }
    public int Damage { get; set; }

    #endregion

    #region Functions

    /// <summary>
    /// Called when the Enemy is taking damage
    /// </summary>
    /// <param name="_amount">The amount of damage to take</param>
    public void TakeDamage(int _amount)
    {
        RemainingHealth -= _amount;

        if (RemainingHealth <= 0)
        {
            Spawner.OnEnemyKilled();
            Destroy(this.gameObject);
        }
    }

    #endregion
}
