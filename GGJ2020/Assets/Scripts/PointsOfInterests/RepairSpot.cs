using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepairSpot : PointOfInterest
{

    #region Members / Properties / Constants

    public int RemainingMaterialsToRepair { get; set; }

    #endregion

    #region Functions

    /// <summary>
    /// Calls the GameManager to reduce the amount of broken RepairSpots
    /// </summary>
    public override void OnClearedInterest()
    {
        GameManager.Instance.RepairSpotIsRepaired(this);
    }

    /// <summary>
    /// Player repairs a part of the RepairSpot
    /// </summary>
    /// <param name="_materialAmount">The material-amount used to repair the Spot</param>
    public void Repair(int _materialAmount)
    {
        RemainingMaterialsToRepair -= _materialAmount;

        if (RemainingMaterialsToRepair <= 0)
            this.m_Room.Status = RoomStatus.Cleared;
    }

    #endregion
}
