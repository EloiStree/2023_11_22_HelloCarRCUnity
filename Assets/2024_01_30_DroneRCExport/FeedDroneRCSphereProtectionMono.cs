using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedDroneRCSphereProtectionMono : MonoBehaviour, I_DroneGameShapeMetaInfoFeeder
{
    public DroneRCSphereProtectionMono m_toAffect;
    public Transform m_droneCenterReference;
    public Transform m_protectionCenter;
    public Transform m_protectionRadiusAnchor;

    [ContextMenu("Feed push shape info")]
    public void FeedPushInformation()
    {
        m_toAffect.m_shapeInfo.m_hasSphereProtection = m_protectionCenter.gameObject.activeSelf;
        m_toAffect.m_shapeInfo.m_sphereRadius = Vector3.Distance(m_protectionCenter.position, m_protectionRadiusAnchor.position);
        ExportDroneLocationUtility.GetWorldToLocal_Point(m_protectionCenter.position, m_droneCenterReference, out m_toAffect.m_shapeInfo.m_sphereCenterOffset);

    }

}
