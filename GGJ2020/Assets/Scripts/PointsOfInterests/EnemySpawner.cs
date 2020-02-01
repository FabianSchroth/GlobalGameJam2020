using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : PointOfInterest
{

    #region Members / Properties / Constants

    public int RemainingEnemys { get; set; }

    #endregion

    #region Functions

    public override void OnClearedInterest()
    {
        // TODO ClearedInterest Funktionalität EnemySpawner
    }

    public void OnEnemyKilled()
    {
        RemainingEnemys--;

        if (RemainingEnemys <= 0)
        {
            OnClearedInterest();
            m_Room.Status = RoomStatus.Cleared;
        }
    }

    #endregion
}
