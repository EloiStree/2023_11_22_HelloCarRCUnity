using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DroneShadowPlanMono : MonoBehaviour
{
    public Transform m_shadowToMove;
    public Transform m_shadowRayDirection;
    public LayerMask m_allowRayCollision;

    void Update()
    {
        if (Physics.Raycast(m_shadowRayDirection.position, m_shadowRayDirection.forward, out RaycastHit hit, float.MaxValue, m_allowRayCollision)) {
            m_shadowToMove.position = hit.point;
            m_shadowToMove.forward = m_shadowRayDirection.forward;
            m_shadowToMove.Translate(Vector3.back*0.01f, Space.Self);
        }
        
    }
}
