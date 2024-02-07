using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingSnitchRecenterMono : MonoBehaviour
{

    public Transform m_whereIsCenter;
    public Transform m_whatToMove;

    public bool m_isActive = true;
    public float m_speed = 0.1f;
    public float m_arriveRadius = 0.1f;
    void Update()
    {
        if (Vector3.Distance(m_whereIsCenter.position, m_whatToMove.position) < m_arriveRadius)
            return;           
        m_whatToMove.position += (m_whereIsCenter.position - m_whatToMove.position).normalized *
            m_speed * Time.deltaTime;
    }
}