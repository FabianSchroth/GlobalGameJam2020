using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PointOfInterest : MonoBehaviour
{

    #region Members / Properties / Constants

    public Room m_Room;

    #endregion

    #region Functions

    public abstract void OnClearedInterest();

    #endregion
}
