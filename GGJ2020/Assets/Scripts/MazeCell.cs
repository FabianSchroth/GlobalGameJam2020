using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MazeCell
{
    public bool visited = false;

    public bool north, south, east, west;

    public MazeCell()
    {
        north = false;
        south = false;
        east = false;
        west = false;
    }
}
