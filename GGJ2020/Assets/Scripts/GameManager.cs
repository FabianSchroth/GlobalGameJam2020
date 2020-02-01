using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Members / Properties / Constants 

    private static GameManager m_Instance;
    public static GameManager Instance { get { return m_Instance; } set { m_Instance = value; } }

    private Vector2Int m_CurrentRoomIndex;
    private Room[,] m_Map;
    private int m_StageIndex;


    [SerializeField]
    private int m_RepairSpotsToRepair;
    [SerializeField]
    private EndRoom m_EndRoom;

    #endregion

    #region Functions

    /// <summary>
    /// TODO Kommentar:
    /// </summary>
    public void EnterRoom(MoveDirection _direction)
    {
        switch (_direction)
        {
            case MoveDirection.Top:
                m_CurrentRoomIndex.y++;
                break;
            case MoveDirection.Down:
                m_CurrentRoomIndex.y--;
                break;
            case MoveDirection.Left:
                m_CurrentRoomIndex.x--;
                break;
            case MoveDirection.Right:
                m_CurrentRoomIndex.x++;
                break;
            default:
                break;
        }

        m_Map[m_CurrentRoomIndex.x, m_CurrentRoomIndex.y].Status = RoomStatus.PlayerInside;
    }

    /// <summary>
    /// Called when a Repair Spot has been repaired
    /// </summary>
    public void RepairSpotIsRepaired()
    {
        m_RepairSpotsToRepair--;

        if (m_RepairSpotsToRepair <= 0)
            m_EndRoom.DoorIsOpen = true;
    }

    #endregion

    #region Unity Lifecycle

    private void Awake()
    {
        if (m_Instance != null && m_Instance != this)
            Destroy(this.gameObject);
        else
            m_Instance = this;
    }

    private void Start()
    {
        m_StageIndex = 1;
        DontDestroyOnLoad(this.gameObject);
    }

    #endregion
}
