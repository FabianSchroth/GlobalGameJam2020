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
        // TODO ClearedInterest Funktionalität
    }

    public void OnEnemyKilled()
    {
        m_RemainingEnemys--;

        if (m_RemainingEnemys <= 0)
        {
            OnClearedInterest();
            m_Room.Status = RoomStatus.Cleared;
        }
    }

    #endregion
}
