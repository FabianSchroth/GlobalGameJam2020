using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{

    #region Members / Properties / Constants

    GameObject m_RoomPrefab;
    [HideInInspector]
    public GameObject m_PointOfInterest;
    [HideInInspector]
    public PointOfInterest m_PointOfInterestComponent;
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

    public Transform m_TopSpawnPointPlayer;
    public Transform m_DownSpawnPointPlayer;
    public Transform m_LeftSpawnPointPlayer;
    public Transform m_RightSpawnPointPlayer;

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

    /// <summary>
    /// Defines the room as the Start Room
    /// </summary>
    public void SetStartRoom()
    {
        this.m_PointOfInterest = Instantiate(GameManager.Instance.m_StartRoomPoIPrefab, m_PointOfInterestPosition);
        this.m_PointOfInterestComponent = this.m_PointOfInterest.GetComponent<PointOfInterest>();
    }

    /// <summary>
    /// Called when the room is defined as the end room
    /// </summary>
    public void SetEndRoom()
    {
        this.m_PointOfInterest = Instantiate(GameManager.Instance.m_EndRoomPoIPrefab, m_PointOfInterestPosition);
        this.m_PointOfInterestComponent = this.m_PointOfInterest.GetComponent<PointOfInterest>();
    }

    /// <summary>
    /// Called when the room contains a RepairSpot
    /// </summary>
    public void SetRepairSpot()
    {
        this.m_PointOfInterest = Instantiate(GameManager.Instance.m_RepairSpotPoIPrefab, m_PointOfInterestPosition);
        this.m_PointOfInterestComponent = this.m_PointOfInterest.GetComponent<PointOfInterest>();
    }

    /// <summary>
    /// Called when the room contains an EnemySpawner
    /// </summary>
    public void SetEnemySpawner()
    {
        this.m_PointOfInterest = Instantiate(GameManager.Instance.m_EnemySpawnerPoIPrefab, m_PointOfInterestPosition);
        this.m_PointOfInterestComponent = this.m_PointOfInterest.GetComponent<PointOfInterest>();
    }

    /// <summary>
    /// Called when the room is defined as the TreasureRoom
    /// </summary>
    public void SetTreasureChest()
    {
        this.m_PointOfInterest = Instantiate(GameManager.Instance.m_TreasureRoomPoIPrefab, m_PointOfInterestPosition);
        this.m_PointOfInterestComponent = this.m_PointOfInterest.GetComponent<PointOfInterest>();
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
        int enemyAmount = 0;

        if (m_PointOfInterestComponent is EnemySpawner)
        {
            //LockDoors();
            enemyAmount = GameManager.Instance.RollDice(3) + 1;
            EnemySpawner enemySpawner = m_PointOfInterestComponent as EnemySpawner;
            enemySpawner.RemainingEnemys = enemyAmount;
        }

        //TODO: Fixe TransformPoints für Positionswechsel?
        switch (GameManager.Instance.m_MoveDirection)
        {
            case MoveDirection.Top:
                GameManager.Instance.m_Player.transform.position = m_DownSpawnPointPlayer.position + Vector3.up;
                // Spawn Up To 3 Enemies
                if (enemyAmount > 0)
                {
                    Instantiate(GameManager.Instance.m_EnemyPrefabs[GameManager.Instance.RollDice(GameManager.Instance.m_EnemyPrefabs.Count)], m_LeftSpawnPointPlayer.position, Quaternion.identity);
                    enemyAmount--;

                    if (enemyAmount > 0)
                    {
                        Instantiate(GameManager.Instance.m_EnemyPrefabs[GameManager.Instance.RollDice(GameManager.Instance.m_EnemyPrefabs.Count)], m_TopSpawnPointPlayer.position, Quaternion.identity);
                        enemyAmount--;

                        if (enemyAmount > 0)
                            Instantiate(GameManager.Instance.m_EnemyPrefabs[GameManager.Instance.RollDice(GameManager.Instance.m_EnemyPrefabs.Count)], m_RightSpawnPointPlayer.position, Quaternion.identity);
                    }
                }
                break;
            case MoveDirection.Down:
                GameManager.Instance.m_Player.transform.position = m_TopSpawnPointPlayer.position + Vector3.up;
                // Spawn Up To 3 Enemies
                if (enemyAmount > 0)
                {
                    Instantiate(GameManager.Instance.m_EnemyPrefabs[GameManager.Instance.RollDice(GameManager.Instance.m_EnemyPrefabs.Count)], m_RightSpawnPointPlayer.position, Quaternion.identity);
                    enemyAmount--;

                    if (enemyAmount > 0)
                    {
                        Instantiate(GameManager.Instance.m_EnemyPrefabs[GameManager.Instance.RollDice(GameManager.Instance.m_EnemyPrefabs.Count)], m_DownSpawnPointPlayer.position, Quaternion.identity);
                        enemyAmount--;

                        if (enemyAmount > 0)
                            Instantiate(GameManager.Instance.m_EnemyPrefabs[GameManager.Instance.RollDice(GameManager.Instance.m_EnemyPrefabs.Count)], m_LeftSpawnPointPlayer.position, Quaternion.identity);
                    }
                }
                break;
            case MoveDirection.Left:
                GameManager.Instance.m_Player.transform.position = m_RightSpawnPointPlayer.position + Vector3.up;
                // Spawn Up To 3 Enemies
                if (enemyAmount > 0)
                {
                    Instantiate(GameManager.Instance.m_EnemyPrefabs[GameManager.Instance.RollDice(GameManager.Instance.m_EnemyPrefabs.Count)], m_DownSpawnPointPlayer.position, Quaternion.identity);
                    enemyAmount--;

                    if (enemyAmount > 0)
                    {
                        Instantiate(GameManager.Instance.m_EnemyPrefabs[GameManager.Instance.RollDice(GameManager.Instance.m_EnemyPrefabs.Count)], m_LeftSpawnPointPlayer.position, Quaternion.identity);
                        enemyAmount--;

                        if (enemyAmount > 0)
                            Instantiate(GameManager.Instance.m_EnemyPrefabs[GameManager.Instance.RollDice(GameManager.Instance.m_EnemyPrefabs.Count)], m_TopSpawnPointPlayer.position, Quaternion.identity);
                    }
                }
                break;
            case MoveDirection.Right:
                GameManager.Instance.m_Player.transform.position = m_LeftSpawnPointPlayer.position + Vector3.up;
                // Spawn Up To 3 Enemies
                if (enemyAmount > 0)
                {
                    Instantiate(GameManager.Instance.m_EnemyPrefabs[GameManager.Instance.RollDice(GameManager.Instance.m_EnemyPrefabs.Count)], m_TopSpawnPointPlayer.position, Quaternion.identity);
                    enemyAmount--;

                    if (enemyAmount > 0)
                    {
                        Instantiate(GameManager.Instance.m_EnemyPrefabs[GameManager.Instance.RollDice(GameManager.Instance.m_EnemyPrefabs.Count)], m_RightSpawnPointPlayer.position, Quaternion.identity);
                        enemyAmount--;

                        if (enemyAmount > 0)
                            Instantiate(GameManager.Instance.m_EnemyPrefabs[GameManager.Instance.RollDice(GameManager.Instance.m_EnemyPrefabs.Count)], m_DownSpawnPointPlayer.position, Quaternion.identity);
                    }
                }
                break;
            default:
                break;
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
