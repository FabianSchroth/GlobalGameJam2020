﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MazeGenerator : MonoBehaviour
{
    const float WALLOFFSET = 3;

    [SerializeField]
    GameObject m_WallPrefab;
    [SerializeField]
    GameObject m_FloorPrefab;

    [SerializeField]
    Vector2Int m_Size;

    [SerializeField]
    int m_Seed;

    public MazeCell[,] GenerateMaze(int _x, int _y, int _seed)
    {
        System.Random rng = new System.Random(_seed);

        MazeCell[,] maze = new MazeCell[_x,_y];

        // algorithm here
        Vector2Int currentPos = new Vector2Int(0, 0);
        int counterFilled = 0;
        int cellCount = maze.GetLength(0) * maze.GetLength(1);
        Stack<Vector2Int> backtrackStack = new Stack<Vector2Int>();

        while (counterFilled < cellCount)
        {
            maze[currentPos.x, currentPos.y].visited = true;
            Vector2Int[] notVisitedNeighbours = GetNotVisitedNeighbours(currentPos, maze);
            if (notVisitedNeighbours.Length > 0)
            {
                if (notVisitedNeighbours.Length > 1)
                {
                    backtrackStack.Push(currentPos);
                }

                int randomNeighbour = rng.Next(notVisitedNeighbours.Length);
                counterFilled++;

                Vector2Int nextPosition = notVisitedNeighbours[randomNeighbour];

                Vector2Int direction = nextPosition - currentPos;
                if (direction == Vector2Int.up)
                {
                    maze[currentPos.x, currentPos.y].north = false;
                }
                else if (direction == Vector2Int.down)
                {
                    maze[currentPos.x, currentPos.y].south = false;
                }
                else if (direction == Vector2Int.left)
                {
                    maze[currentPos.x, currentPos.y].west = false;
                }
                else if (direction == Vector2Int.right)
                {
                    maze[currentPos.x, currentPos.y].east = false;
                }


                currentPos = nextPosition;
            }
            else if (backtrackStack.Count > 0)            
            {
                currentPos = backtrackStack.Pop();
            }
            else
            {
                break;
            }
        }
        return maze;
    }

    private Vector2Int[] GetNotVisitedNeighbours(Vector2Int _pos, MazeCell[,] _maze)
    {
        MazeCell[,] maze = _maze;

        List<Vector2Int> tempNeighbours = new List<Vector2Int>();
        if (_pos.x > 0)
        {
            if (!maze[_pos.x - 1, _pos.y].visited)
            {
                tempNeighbours.Add(new Vector2Int(_pos.x - 1, _pos.y));
            }
        }
        if (_pos.x < maze.GetLength(0) - 1)
        {
            if (!maze[_pos.x + 1, _pos.y].visited)
            {
                tempNeighbours.Add(new Vector2Int(_pos.x + 1, _pos.y));
            }
        }
        if (_pos.y > 0)
        {
            if (!maze[_pos.x, _pos.y - 1].visited)
            {
                tempNeighbours.Add(new Vector2Int(_pos.x, _pos.y - 1));
            }
        }
        if (_pos.y < maze.GetLength(1) - 1)
        {
            if (!maze[_pos.x, _pos.y + 1].visited)
            {
                tempNeighbours.Add(new Vector2Int(_pos.x, _pos.y + 1));
            }
        }

        return tempNeighbours.ToArray();
    }   
       
}
