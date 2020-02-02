using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : PointOfInterest
{
    public override void OnClearedInterest()
    {
        GameManager.Instance.DetermineRandomWeaponLoot(this.m_Room);
    }
}
