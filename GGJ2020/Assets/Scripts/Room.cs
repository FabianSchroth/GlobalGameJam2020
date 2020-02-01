using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    #region Members / Properties / Constants

    GameObject m_RoomPrefab;
    PointOfInterest m_PointOfInterest;
    Transform m_PointOfInterestPosition;

    private RoomStatus m_Status;
    public RoomStatus Status { get { return m_Status; } set { m_Status = value; OnRoomStatusChanged(); } }

    bool m_HasExitDown;
    bool m_HasExitUp;
    bool m_hasExitLeft;
    bool m_HasExitRight;

    #endregion

    #region Functions

    public void LockDoors()
    {

    }

    public void UnlockDoors()
    {

    }

    /// <summary>
    /// TODO: Kommentar und Funktionalität
    /// </summary>
    public void SetEndRoom()
    {

    }

    /// <summary>
    /// TODO: Kommentar und Funktionalität
    /// </summary>
    public void SetRepairSpot()
    {

    }

    /// <summary>
    /// TODO: Kommentar und Funktionalität
    /// </summary>
    public void SetEnemySpawner()
    {

    }

    /// <summary>
    /// TODO: Kommentar und Funktionalität
    /// </summary>
    public void SetTreasureChest()
    {

    }

    /// <summary>
    /// TODO: Kommentar und Funktionalität
    /// </summary>
    private void OnRoomStatusChanged()
    {
        switch (Status)
        {
            case RoomStatus.Unvisited:
                break;
            case RoomStatus.PlayerInside:
                OnPlayerEnter();
                break;
            case RoomStatus.Cleared:
                break;
            default:
                break;
        }
    }

    private void OnPlayerEnter()
    {
        // When PoI is EnemySpawner, lock the doors
        if (m_PointOfInterest is EnemySpawner)
        {
            LockDoors();
        }
    }

    #endregion

    #region Unity Lifecycle

    private void Start()
    {
        Status = RoomStatus.Unvisited;
    }

    #endregion
}
