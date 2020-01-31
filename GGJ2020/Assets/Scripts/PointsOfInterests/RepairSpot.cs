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
    /// TODO: Kommentar
    /// </summary>
    public override void OnClearedInterest()
    {
        GameManager.Instance.RepairSpotIsRepaired();
    }

    #endregion
}
