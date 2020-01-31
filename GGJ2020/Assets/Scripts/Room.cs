using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    #region Members / Properties / Constants

    GameObject m_RoomPrefab;
    PointOfInterest m_PointOfInterest;
    Transform m_PointOfInterestPosition;

    RoomStatus m_Status;

    bool m_HasExitDown;
    bool m_HasExitUp;
    bool m_hasExitLeft;
    bool m_HasExitRight;

    #endregion

    #region Functions

    public void SetEndRoom()
    {

    }

    public void SetRepairSpot()
    {

    }

    public void SetEnemySpawner()
    {

    }

    public void SetTreasureChest()
    {

    }

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        m_Status = RoomStatus.Unvisited;
    }

    #endregion
}
