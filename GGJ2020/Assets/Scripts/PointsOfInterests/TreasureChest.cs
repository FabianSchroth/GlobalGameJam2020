using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : PointOfInterest
{
    public override void OnClearedInterest()
    {
        GameManager.Instance.DetermineRandomWeaponLoot(this.m_Room);
    }

    bool dropped = false;

    public void DropWeapon()
    {
        if (!dropped)
        {
            Instantiate(GameManager.Instance.DropWeapons[Random.Range(0, 5)], transform.position + transform.forward, Quaternion.identity);
            dropped = true;
        }
    }
}
