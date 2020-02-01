using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndRoom : PointOfInterest
{

    #region Members / Properties / Constants

    private bool m_DoorIsOpen;
    public bool DoorIsOpen { get { return m_DoorIsOpen; } set { m_DoorIsOpen = value; OnDoorIsOpen(value); } }

    #endregion

    #region Functions

    /// <summary>
    /// Player finished the current stage -> Increase the stageIndex and generate a new stage by reloading the game scene
    /// </summary>
    public override void OnClearedInterest()
    {
        GameManager.Instance.m_StageIndex++;
        SceneManager.LoadScene(1);
    }

    /// <summary>
    /// TODO Kommentar
    /// </summary>
    /// <param name="_value"></param>
    private void OnDoorIsOpen(bool _value)
    {
        if (_value)
        {
            // TODO: Door Is Open
        }
    }

    #endregion
}
