using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Members / Properties / Constants 

    private static GameManager m_Instance;
    public static GameManager Instance { get { return m_Instance; } set { m_Instance = value; } }

    //private Vector2Int m_CurrentRoomIndex;
    public int m_CurrentRoomIndexX = 2;
    public int m_CurrentRoomIndexY = 2;

    private Room[,] m_Map;
    public int m_StageIndex;

    public Player m_Player;
    public MoveDirection m_MoveDirection;

    public Material m_RepairSpotDoneMaterial;

    // Prefabs
    [SerializeField]
    private List<GameObject> m_RoomPrefabs;
    [SerializeField]
    private List<GameObject> m_WeaponPrefabs;
    [SerializeField]
    private List<GameObject> m_BuffPrefabs;
    public List<GameObject> m_EnemyPrefabs;
    public GameObject m_MimicPrefab;
    public GameObject m_RegenerateHealthPrefab;
    public GameObject m_RepairCurrencyPrefab;

    public GameObject m_EnemySpawnerPoIPrefab;
    public GameObject m_RepairSpotPoIPrefab;
    public GameObject m_EndRoomPoIPrefab;
    public GameObject m_StartRoomPoIPrefab;
    public GameObject m_TreasureRoomPoIPrefab;

    [SerializeField]
    private int m_RepairSpotsToRepair;
    [SerializeField]
    private EndRoom m_EndRoom;

    [SerializeField]
    private Texture2D m_Cursor;

    private System.Random RNG { get; set; }

    public const int ROOM_OFFSET = 50;
    public const float PLAYER_SPAWN_OFFSET = 5f;

    #endregion

    #region Functions

    private void CreateMap()
    {
        MazeGenerator mazeGenerator = new MazeGenerator();
        MazeCell[,] mazeCells = mazeGenerator.GenerateMaze(5, 5, RollDice(1000));
        int mazeCellSizeX = mazeCells.GetLength(0);
        int mazeCellSizeY = mazeCells.GetLength(1);

        m_Map = new Room[mazeCellSizeX, mazeCellSizeY];

        for (int x = 0; x < mazeCellSizeX; x++)
        {
            for (int y = 0; y < mazeCellSizeY; y++)
            {
                GameObject room = Instantiate(m_RoomPrefabs[RollDice(m_RoomPrefabs.Count)], new Vector3 (x * ROOM_OFFSET, 0, y * ROOM_OFFSET), Quaternion.identity);
                m_Map[x, y] = room.GetComponent<Room>();

                // Set Exits
                m_Map[x, y].HasExitTop = mazeCells[x, y].top;
                m_Map[x, y].HasExitDown = mazeCells[x, y].down;
                m_Map[x, y].HasExitLeft = mazeCells[x, y].left;
                m_Map[x, y].HasExitRight = mazeCells[x, y].right;

                // Set Enemy Spawner As Default
                m_Map[x, y].SetEnemySpawner();
            }
        }

        // Overwrite PoIs for needed PoIs
        m_Map[2, 2].SetStartRoom();

        int diceRollX;
        int diceRollY;
        bool PoIsSet = false;
        bool endRoomSet = false;
        bool treasureRoomSet = false;

        do
        {
            if (m_RepairSpotsToRepair < 4)
            {
                diceRollX = RollDice(5);
                diceRollY = RollDice(5);

                if (m_Map[diceRollX,diceRollY].m_PointOfInterestComponent is EnemySpawner)
                {
                    m_Map[diceRollX, diceRollY].SetRepairSpot();
                    m_RepairSpotsToRepair++;
                }
            }
            else
            {
                if (!endRoomSet)
                {
                    diceRollX = RollDice(5);
                    diceRollY = RollDice(5);

                    if (m_Map[diceRollX, diceRollY].m_PointOfInterestComponent is EnemySpawner)
                    {
                        m_Map[diceRollX, diceRollY].SetEndRoom();
                        m_EndRoom = m_Map[diceRollX, diceRollY].m_PointOfInterestComponent as EndRoom;
                        endRoomSet = true;
                    }
                }
                else
                {
                    if (!treasureRoomSet)
                    {
                        diceRollX = RollDice(5);
                        diceRollY = RollDice(5);

                        if (m_Map[diceRollX, diceRollY].m_PointOfInterestComponent is EnemySpawner)
                        {
                            m_Map[diceRollX, diceRollY].SetTreasureChest();
                            treasureRoomSet = true;
                        }
                    }
                    else
                        PoIsSet = true;
                }
            }
        } while (!PoIsSet);

        m_Player.transform.position = m_Map[2, 2].m_DownSpawnPointPlayer.position + Vector3.up;
        m_CurrentRoomIndexX = 2;
        m_CurrentRoomIndexY = 2;

    }


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
        return RNG.Next(0, _excludedMaxValue);
    }

    /// <summary>
    /// Called when the player decides to enter a new room
    /// </summary>
    public void EnterNewRoom(MoveDirection _direction)
    {
        m_MoveDirection = _direction;

        switch (_direction)
        {
            case MoveDirection.Top:
                m_CurrentRoomIndexY++;
                break;
            case MoveDirection.Down:
                m_CurrentRoomIndexY--;
                break;
            case MoveDirection.Left:
                m_CurrentRoomIndexX--;
                break;
            case MoveDirection.Right:
                m_CurrentRoomIndexX++;
                break;
            default:
                break;
        }
        Debug.Log($"{m_CurrentRoomIndexX},{m_CurrentRoomIndexY}");
        m_Map[m_CurrentRoomIndexX, m_CurrentRoomIndexY].Status = RoomStatus.PlayerInside;
    }

    /// <summary>
    /// Called when a Repair Spot has been repaired
    /// </summary>
    public void RepairSpotIsRepaired(RepairSpot _caller)
    {
        Material[] materials = _caller.GetComponent<MeshRenderer>()?.materials;
        materials[materials.Length - 1] = m_RepairSpotDoneMaterial;

        m_RepairSpotsToRepair--;

        if (m_RepairSpotsToRepair <= 0)
            m_EndRoom.DoorIsOpen = true;
    }

    /// <summary>
    /// 
    /// </summary>
    public void CheckForEnemySpawnerDrop()
    {
        // TODO: Roll Dice and Spawn Stuff
    }

    public void SwitchRoomFade(float _duration, System.Action _action)
    {
        Player.Instance.SwitchRoomFade(_duration,_action);
    }

    /// <summary>
    /// Rolls on the table for possible weapon drops and spawns the weapon
    /// </summary>
    /// <returns>The rolled weapon to spawn</returns>
    public GameObject DetermineRandomWeaponLoot(Room _caller)
    {
        return Instantiate(m_WeaponPrefabs[RollDice(m_WeaponPrefabs.Count)], _caller.m_PointOfInterestPosition);
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
        RNG = new System.Random();

        m_StageIndex = 1;
        DontDestroyOnLoad(this.gameObject);
        Cursor.SetCursor(m_Cursor, new Vector2(32,28), CursorMode.ForceSoftware);
        CreateMap();
    }

    #endregion
}
