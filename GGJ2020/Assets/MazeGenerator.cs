using System.Collections;
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

    MazeCell[,] m_Maze;

    private void Start()
    {
        BuildMaze();
    }

    public void BuildMaze()
    {
        BuildMazeCells(m_Size);
        BuildOuterBounds(m_Size);
        MazeAlgorithm();        
    }

    private void MazeAlgorithm()
    {
        System.Random rng = new System.Random(m_Seed);

        // algorithm here
        Vector2Int currentPos = new Vector2Int(0, 0);
        int counterFilled = 0;
        int cellCount = m_Maze.GetLength(0) * m_Maze.GetLength(1);
        Stack<Vector2Int> backtrackStack = new Stack<Vector2Int>();

        while (counterFilled < cellCount)
        {
            m_Maze[currentPos.x, currentPos.y].m_Visited = true;
            Vector2Int[] notVisitedNeighbours = GetNotVisitedNeighbours(currentPos);
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
                    Debug.Log(m_Maze[currentPos.x, currentPos.y].m_North);
                    m_Maze[currentPos.x, currentPos.y].m_North.SetActive(false);
                }
                else if (direction == Vector2Int.down)
                {
                    m_Maze[currentPos.x, currentPos.y].m_South.SetActive(false);
                }
                else if (direction == Vector2Int.left)
                {
                    m_Maze[currentPos.x, currentPos.y].m_West.SetActive(false);
                }
                else if (direction == Vector2Int.right)
                {
                    m_Maze[currentPos.x, currentPos.y].m_East.SetActive(false);
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
    }

    private Vector2Int[] GetNotVisitedNeighbours(Vector2Int _pos)
    {
        List<Vector2Int> tempNeighbours = new List<Vector2Int>();
        if (_pos.x > 0)
        {
            if (!m_Maze[_pos.x - 1, _pos.y].m_Visited)
            {
                tempNeighbours.Add(new Vector2Int(_pos.x - 1, _pos.y));
            }
        }
        if (_pos.x < m_Maze.GetLength(0) - 1)
        {
            if (!m_Maze[_pos.x + 1, _pos.y].m_Visited)
            {
                tempNeighbours.Add(new Vector2Int(_pos.x + 1, _pos.y));
            }
        }
        if (_pos.y > 0)
        {
            if (!m_Maze[_pos.x, _pos.y - 1].m_Visited)
            {
                tempNeighbours.Add(new Vector2Int(_pos.x, _pos.y - 1));
            }
        }
        if (_pos.y < m_Maze.GetLength(1) - 1)
        {
            if (!m_Maze[_pos.x, _pos.y + 1].m_Visited)
            {
                tempNeighbours.Add(new Vector2Int(_pos.x, _pos.y + 1));
            }
        }

        return tempNeighbours.ToArray();
    }

    private void BuildMazeCells(Vector2Int _size)
    {
        m_Maze = new MazeCell[_size.x, _size.y];
        for (int x = 0; x < _size.x; x++)
        {
            for (int y = 0; y < _size.y; y++)
            {
                m_Maze[x, y] = new MazeCell();
            }
        }
    }

    private void BuildOuterBounds(Vector2Int _size)
    {
        for (int i = 0; i < _size.x; i++)
        {
            float pos = i * WALLOFFSET;
            Instantiate(m_WallPrefab, new Vector3(pos, 0, 0), Quaternion.Euler(new Vector3(0, 180, 0)), transform);
            for (int y = 0; y < _size.y; y++)
            {
                Instantiate(m_FloorPrefab, new Vector3(pos + WALLOFFSET, 0, y * WALLOFFSET), Quaternion.Euler(new Vector3(0, 0, 0)), transform);
            }
        }
        for (int i = 0; i < _size.y; i++)
        {
            float pos = i * WALLOFFSET + WALLOFFSET;
            Instantiate(m_WallPrefab, new Vector3(0, 0, pos), Quaternion.Euler(new Vector3(0, -90, 0)), transform);
        }

        for (int x = 0; x < _size.x; x++)
        {
            for (int y = 0; y < _size.y; y++)
            {
                GameObject wallRight = Instantiate(m_WallPrefab, new Vector3((x + 1) * WALLOFFSET, 0, (y+1) * WALLOFFSET), Quaternion.Euler(new Vector3(0, -90, 0)), transform);
                GameObject wallTop = Instantiate(m_WallPrefab, new Vector3(x * WALLOFFSET, 0, (y + 1) * WALLOFFSET), Quaternion.Euler(new Vector3(0, 180, 0)), transform);
                wallRight.name = "Right" + x + y;
                wallTop.name = "Top" + x + y;

                if (y < _size.y - 1)
                {
                    m_Maze[x, y].m_North = wallTop;
                }

                if (x < _size.x - 1)
                {
                    m_Maze[x, y].m_East = wallRight;
                }

                if (y < _size.y - 1)
                {
                    m_Maze[x, y + 1].m_South = wallTop;
                }

                if (x < _size.x - 1)
                {
                    m_Maze[x + 1, y].m_West = wallRight;
                }
            }
        }
    }
}
