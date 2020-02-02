using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
        Application.Quit();
    }



    //DEBUGGING PURPOSE ONLY

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            DebugGoToNewRoom();
        }
    }

    public void DebugGoToNewRoom()
    {
        Room currentRoom = GameManager.Instance.m_Map[GameManager.Instance.m_CurrentRoomIndexX, GameManager.Instance.m_CurrentRoomIndexY];
        if (currentRoom.HasExitTop)
            GameManager.Instance.EnterNewRoom(MoveDirection.Top);
        else if (currentRoom.HasExitRight)
            GameManager.Instance.EnterNewRoom(MoveDirection.Right);
        else if (currentRoom.HasExitDown)
            GameManager.Instance.EnterNewRoom(MoveDirection.Down);
        else if (currentRoom.HasExitLeft)
            GameManager.Instance.EnterNewRoom(MoveDirection.Left);


    }
}
