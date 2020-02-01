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

    // Prefabs
    [SerializeField]
    private List<GameObject> m_WeaponPrefabs;
    [SerializeField]
    private List<GameObject> m_BuffPrefabs;
    public GameObject m_MimicPrefab;
    public GameObject m_RegenerateHealthPrefab;
    public GameObject m_RepairCurrencyPrefab;

    [SerializeField]
    private int m_RepairSpotsToRepair;
    [SerializeField]
    private EndRoom m_EndRoom;

    [SerializeField]
    private Texture2D m_Cursor;

    #endregion

    #region Functions

    /// <summary>
    /// Start function for game over situation
    /// </summary>
    public void EndGame()
    {
        // TODO: Game Over
    }

    /// <summary>
    /// "Rolls a dice" to get a random integer value in a given range
    /// </summary>
    /// <param name="_excludedMaxValue">The excluded max value</param>
    /// <returns>The random integer</returns>
    public int RollDice(int _excludedMaxValue)
    {
        System.Random random = new System.Random();
        return random.Next(0, _excludedMaxValue);
    }

    /// <summary>
    /// Called when the player decides to enter a new room
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

    /// <summary>
    /// 
    /// </summary>
    public void CheckForEnemySpawnerDrop()
    {
        // TODO: Roll Die and Spawn Stuff
    }

    /// <summary>
    /// Rolls on the table for possible weapon drops and spawns the weapon
    /// </summary>
    /// <returns>The rolled weapon to spawn</returns>
    public GameObject DetermineRandomWeaponLoot()
    {
        // TODO: Position zum Spawnen bestimmen
        return Instantiate(m_WeaponPrefabs[RollDice(m_WeaponPrefabs.Count)]);
    }

    /// <summary>
    /// Rolls on the table for possible buff drops and spawns the buff
    /// </summary>
    /// <returns>The rolled buff to spawn</returns>
    public GameObject DetermineRandomBuffLoot()
    {
        // TODO: Position zum Spawnen bestimmen
        return Instantiate(m_BuffPrefabs[RollDice(m_BuffPrefabs.Count)]);
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
        Cursor.SetCursor(m_Cursor, Vector2.zero, CursorMode.ForceSoftware);
    }

    #endregion
}
