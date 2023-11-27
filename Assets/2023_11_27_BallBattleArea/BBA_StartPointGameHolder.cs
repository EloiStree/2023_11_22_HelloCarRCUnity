using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BBA_StartPointGameHolder : MonoBehaviour
{
    public BBA_StartPoint[] m_startPoints;

    [ContextMenu("Move to start point")]
    public void MoveTargetToStartPoint()
    {
        foreach (var item in m_startPoints)
        {
            item.MoveTargetToStartPoint();
        }
    }
}
