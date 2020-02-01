using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    #region Members / Properties / Constants

    GameObject m_RoomPrefab;
    [HideInInspector]
    public PointOfInterest m_PointOfInterest;
    public Transform m_PointOfInterestPosition;

    private RoomStatus m_Status;
    public RoomStatus Status { get { return m_Status; } set { m_Status = value; OnRoomStatusChanged(); } }

    public Door m_TopDoor;
    public Door m_DownDoor;
    public Door m_LeftDoor;
    public Door m_RightDoor;

    public GameObject m_TopWall;
    public GameObject m_DownWall;
    public GameObject m_LeftWall;
    public GameObject m_RightWall;

    private bool m_HasExitTop;
    public bool HasExitTop { get { return m_HasExitTop; } set { m_HasExitTop = value; m_TopDoor.gameObject.SetActive(value); m_TopWall.SetActive(!value); } }
    private bool m_HasExitDown;
    public bool HasExitDown { get { return m_HasExitDown; } set { m_HasExitDown = value; m_DownDoor.gameObject.SetActive(value); m_DownWall.SetActive(!value); } }
    private bool m_HasExitLeft;
    public bool HasExitLeft { get { return m_HasExitLeft; } set { m_HasExitLeft = value; m_LeftDoor.gameObject.SetActive(value); m_LeftWall.SetActive(!value); } }
    private bool m_HasExitRight;
    public bool HasExitRight { get { return m_HasExitRight; } set { m_HasExitRight = value; m_RightDoor.gameObject.SetActive(value); m_RightWall.SetActive(!value); } }

    #endregion

    #region Functions

    /// <summary>
    /// Locks all doors of a room so the player can not switch the room
    /// </summary>
    public void LockDoors()
    {
        if (HasExitTop)
            m_TopDoor.IsLocked = true;
        if (HasExitDown)
            m_DownDoor.IsLocked = true;
        if (HasExitLeft)
            m_LeftDoor.IsLocked = true;
        if (HasExitRight)
            m_RightDoor.IsLocked = true;
    }

    /// <summary>
    /// Unlocks all doors of a room so the player can switch the room
    /// </summary>
    public void UnlockDoors()
    {
        if (HasExitTop)
            m_TopDoor.IsLocked = false;
        if (HasExitDown)
            m_DownDoor.IsLocked = false;
        if (HasExitLeft)
            m_LeftDoor.IsLocked = false;
        if (HasExitRight)
            m_RightDoor.IsLocked = false;
    }

    public void SetStartRoom()
    {
        this.m_PointOfInterest = new StartRoom();
    }

    /// <summary>
    /// Called when the room is defined as the end room
    /// </summary>
    public void SetEndRoom()
    {
        this.m_PointOfInterest = new EndRoom();
    }

    /// <summary>
    /// Called when the room contains a RepairSpot
    /// </summary>
    public void SetRepairSpot()
    {
        this.m_PointOfInterest = new RepairSpot();
    }

    /// <summary>
    /// Called when the room contains an EnemySpawner
    /// </summary>
    public void SetEnemySpawner()
    {
        this.m_PointOfInterest = new EnemySpawner();
    }

    /// <summary>
    /// Called when the room is defined as the TreasureRoom
    /// </summary>
    public void SetTreasureChest()
    {
        this.m_PointOfInterest = new TreasureChest();
    }

    /// <summary>
    /// Called when the player enters or clears the room
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
        //TODO: Fixe TransformPoints für Positionswechsel?
        switch (GameManager.Instance.m_MoveDirection)
        {
            case MoveDirection.Top:
                GameManager.Instance.m_Player.transform.position = m_DownDoor.transform.position + new Vector3(0,0,GameManager.PLAYER_SPAWN_OFFSET);
                break;
            case MoveDirection.Down:
                GameManager.Instance.m_Player.transform.position = m_TopDoor.transform.position - new Vector3(0, 0, GameManager.PLAYER_SPAWN_OFFSET);
                break;
            case MoveDirection.Left:
                GameManager.Instance.m_Player.transform.position = m_RightDoor.transform.position - new Vector3(GameManager.PLAYER_SPAWN_OFFSET, 0, 0);
                break;
            case MoveDirection.Right:
                GameManager.Instance.m_Player.transform.position = m_RightDoor.transform.position + new Vector3(GameManager.PLAYER_SPAWN_OFFSET, 0, 0);
                break;
            default:
                break;
        }

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
