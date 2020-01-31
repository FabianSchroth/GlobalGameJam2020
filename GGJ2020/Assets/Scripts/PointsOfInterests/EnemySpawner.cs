using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : PointOfInterest
{

    #region Members / Properties / Constants

    int m_RemainingEnemys;


    #endregion



    #region Functions

    public override void OnClearedInterest()
    {
        throw new System.NotImplementedException();
    }

    public void OnEnemyKilled()
    {
        m_RemainingEnemys--;

        if (m_RemainingEnemys <= 0)
        {
            // TODO Set Status To Cleared;
        }
    }

    #endregion
}
