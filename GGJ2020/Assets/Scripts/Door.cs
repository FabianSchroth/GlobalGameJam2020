using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    #region Members / Properties / Constants

    public Room m_Room;
    public bool IsLocked { get; set; }

    #endregion

    #region Unity Lifecycle

    private void OnTriggerEnter(Collider _other)
    {
        if (_other.CompareTag("Player"))
        {
            Debug.Log("Called");

            if (m_Room.m_TopDoor == this && !IsLocked)
                GameManager.Instance.EnterNewRoom(MoveDirection.Top);
            else if (m_Room.m_DownDoor == this && !IsLocked)
                GameManager.Instance.EnterNewRoom(MoveDirection.Down);
            else if (m_Room.m_LeftDoor == this && !IsLocked)
                GameManager.Instance.EnterNewRoom(MoveDirection.Left);
            else if (m_Room.m_RightDoor == this && !IsLocked)
                GameManager.Instance.EnterNewRoom(MoveDirection.Right);
        }
    }

    #endregion
}
