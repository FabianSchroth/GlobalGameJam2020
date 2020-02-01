using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MazeCell
{
    public bool visited = false;

    public bool top, down, left, right;

    public MazeCell()
    {
        top = false;
        down = false;
        left = false;
        right = false;
    }
}
