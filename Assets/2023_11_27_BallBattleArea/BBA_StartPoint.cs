using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BBA_StartPoint : MonoBehaviour
{
    public Transform m_startPoint;
    public Transform m_whatToMove;
    public UnityEvent m_moveRequested;
    [ContextMenu("Move to start point")]
    public void MoveTargetToStartPoint()
    {
        m_whatToMove.position = m_startPoint.position;
        m_whatToMove.rotation = m_startPoint.rotation;
        m_moveRequested.Invoke();
    }

    private void Reset()
    {
        m_startPoint = transform;
        //m_whatToMove = gameObject.GetComponentInChildren<GameObject>()?.transform;
    }
}
