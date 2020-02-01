using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    #region Members / Properties / Constants

    GameObject m_RoomPrefab;
    public PointOfInterest m_PointOfInterest;
    public Transform m_PointOfInterestPosition;

    private RoomStatus m_Status;
    public RoomStatus Status { get { return m_Status; } set { m_Status = value; OnRoomStatusChanged(); } }

    public GameObject m_TopDoor;
    public GameObject m_DownDoor;
    public GameObject m_LeftDoor;
    public GameObject m_RightDoor;

    public GameObject m_TopWall;
    public GameObject m_DownWall;
    public GameObject m_LeftWall;
    public GameObject m_RightWall;

    private bool m_HasExitTop;
    public bool HasExitTop { get { return m_HasExitTop; } set { m_HasExitTop = value; m_TopDoor.SetActive(value); m_TopWall.SetActive(!value); } }
    private bool m_HasExitDown;
    public bool HasExitDown { get { return m_HasExitDown; } set { m_HasExitDown = value; m_DownDoor.SetActive(value); m_DownWall.SetActive(!value); } }
    private bool m_HasExitLeft;
    public bool HasExitLeft { get { return m_HasExitLeft; } set { m_HasExitLeft = value; m_LeftDoor.SetActive(value); m_LeftWall.SetActive(!value); } }
    private bool m_HasExitRight;
    public bool HasExitRight { get { return m_HasExitRight; } set { m_HasExitRight = value; m_RightDoor.SetActive(value); m_RightWall.SetActive(!value); } }

    #endregion

    #region Functions

    public void LockDoors()
    {

    }

    public void UnlockDoors()
    {

    }

    public void SetStartRoom()
    {
        this.m_PointOfInterest = new StartRoom();
    }

    /// <summary>
    /// TODO: Kommentar und Funktionalität
    /// </summary>
    public void SetEndRoom()
    {
        this.m_PointOfInterest = new EndRoom();
    }

    /// <summary>
    /// TODO: Kommentar und Funktionalität
    /// </summary>
    public void SetRepairSpot()
    {
        this.m_PointOfInterest = new RepairSpot();
    }

    /// <summary>
    /// TODO: Kommentar und Funktionalität
    /// </summary>
    public void SetEnemySpawner()
    {
        this.m_PointOfInterest = new EnemySpawner();
    }

    /// <summary>
    /// TODO: Kommentar und Funktionalität
    /// </summary>
    public void SetTreasureChest()
    {
        this.m_PointOfInterest = new TreasureChest();
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
