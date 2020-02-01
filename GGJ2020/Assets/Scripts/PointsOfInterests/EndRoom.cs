using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndRoom : PointOfInterest
{

    #region Members / Properties / Constants

    private bool m_DoorIsOpen;
    public bool DoorIsOpen { get { return m_DoorIsOpen; } set { m_DoorIsOpen = value; OnDoorIsOpen(value); } }

    #endregion

    #region Functions

    public override void OnClearedInterest()
    {
        // TODO: Load Next Level
    }

    private void OnDoorIsOpen(bool _value)
    {
        if (_value)
        {
            // TODO: Door Is Open
        }
    }

    #endregion
}
