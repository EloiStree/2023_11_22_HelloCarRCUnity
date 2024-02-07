using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedCarRCShapeMetaInfoMono : MonoBehaviour, I_DroneGameShapeMetaInfoFeeder
{
    public CarRCShapeMetaInfoMono m_toAffect;


    public Transform m_carRcCenterReference;

    public Transform m_wheelOffsetFrontLeft;
    public Transform m_wheelOffsetFrontRight;
    public Transform m_wheelOffsetBackLeft;
    public Transform m_wheelOffsetBackRight;
    
    public Transform m_radiusOfWheelsFrontLeft;
    public Transform m_heightOfWheelsFrontLeft;
    
    public Transform m_boxCarColliderOffset;
    public Transform m_boxCarColliderOffsetAnchorFTR;
    public Transform m_boxCarBodyColliderOffset;
    public Transform m_boxCarBodyColliderOffsetAnchorFTR;


    [ContextMenu("Feed push shape info")]
    public void FeedPushInformation()
    {
        ExportDroneLocationUtility.GetWorldToLocal_Point(
            m_wheelOffsetFrontLeft.position, m_carRcCenterReference, 
            out m_toAffect.m_shapeInfo.m_wheelOffsetFrontLeft);
        ExportDroneLocationUtility.GetWorldToLocal_Point(
            m_wheelOffsetFrontRight.position, m_carRcCenterReference, 
            out m_toAffect.m_shapeInfo.m_wheelOffsetFrontRight);
        ExportDroneLocationUtility.GetWorldToLocal_Point(
            m_wheelOffsetBackLeft.position, m_carRcCenterReference, 
            out m_toAffect.m_shapeInfo.m_wheelOffsetBackLeft);
        ExportDroneLocationUtility.GetWorldToLocal_Point(
            m_wheelOffsetBackRight.position, m_carRcCenterReference,
            out m_toAffect.m_shapeInfo.m_wheelOffsetBackRight);

        m_toAffect.m_shapeInfo.m_radiusOfWheels =
             Vector3.Distance(m_wheelOffsetFrontLeft.position, m_radiusOfWheelsFrontLeft.position);
        m_toAffect.m_shapeInfo.m_heightOfWheels=
             Vector3.Distance(m_wheelOffsetFrontLeft.position, m_heightOfWheelsFrontLeft.position)*2f;



        ExportDroneLocationUtility.GetWorldToLocal_Point(
            m_boxCarColliderOffset.position, m_carRcCenterReference,
            out m_toAffect.m_shapeInfo.m_boxCarColliderOffset);

        ExportDroneLocationUtility.GetWorldToLocal_Point(
            m_boxCarBodyColliderOffset.position, m_carRcCenterReference,
            out m_toAffect.m_shapeInfo.m_boxCarBodyColliderOffset);

        m_toAffect.m_shapeInfo.m_heightOfCarCollider = Mathf.Abs(m_boxCarColliderOffset.position.y - m_boxCarColliderOffsetAnchorFTR.position.y) * 2;
        m_toAffect.m_shapeInfo.m_widthOfCarCollider = Mathf.Abs(m_boxCarColliderOffset.position.x - m_boxCarColliderOffsetAnchorFTR.position.x) * 2;
        m_toAffect.m_shapeInfo.m_depthOfCarCollider = Mathf.Abs(m_boxCarColliderOffset.position.z - m_boxCarColliderOffsetAnchorFTR.position.z) * 2;

        m_toAffect.m_shapeInfo.m_heightOfCarBodyCollider = Mathf.Abs(m_boxCarBodyColliderOffset.position.y - m_boxCarBodyColliderOffsetAnchorFTR.position.y) * 2;
        m_toAffect.m_shapeInfo.m_widthOfCarBodyCollider = Mathf.Abs(m_boxCarBodyColliderOffset.position.x - m_boxCarBodyColliderOffsetAnchorFTR.position.x) * 2;
        m_toAffect.m_shapeInfo.m_depthOfCarBodyCollider = Mathf.Abs(m_boxCarBodyColliderOffset.position.z - m_boxCarBodyColliderOffsetAnchorFTR.position.z) * 2;


    }


}
