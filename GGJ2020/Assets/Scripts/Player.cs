using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    #region Members / Properties / Constants

    int m_RemainingHealth;
    int m_MaxHealth;

    public Weapon CurrentWeapon { get; set; }

    #endregion

    #region Functions

    /// <summary>
    /// Called when the player got hit by an enemy
    /// </summary>
    /// <param name="_amount">The amount of damage to take</param>
    public void TakeDamage(int _amount)
    {
        m_RemainingHealth -= _amount;

        //TODO: Update GUI

        if (m_RemainingHealth <= 0)
        {
            // TODO: Game Over
        }
    }

    #endregion
}
