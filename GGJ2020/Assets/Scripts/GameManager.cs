using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Members / Properties / Constants 

    private static GameManager m_Instance;
    public static GameManager Instance { get { return m_Instance; } set { m_Instance = value; } }

    [SerializeField]
    private int m_RepairSpotsToRepair;
    [SerializeField]
    private EndRoom m_EndRoom;

    #endregion

    #region Functions

    /// <summary>
    /// TODO Kommentar:
    /// </summary>
    public void SwapRoom()
    {

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

    #endregion
}
