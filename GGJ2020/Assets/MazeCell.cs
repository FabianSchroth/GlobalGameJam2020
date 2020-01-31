using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MazeCell
{
    public bool m_Visited = false;

    public GameObject m_North, m_South, m_East, m_West;
}
