using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedGameBallShapeMetaInfoMono : MonoBehaviour, I_DroneGameShapeMetaInfoFeeder
{
    public GameBallShapeMetaInfoMono m_toAffect;
    public SphereCollider m_ballCollider;

    [ContextMenu("Feed push shape info")]
    public void FeedPushInformation()
    {
        m_toAffect.m_shapeInfo.m_ballRadius = m_ballCollider.radius;
    }
    
}
