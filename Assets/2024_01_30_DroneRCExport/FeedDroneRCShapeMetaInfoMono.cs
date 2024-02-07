using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedDroneRCShapeMetaInfoMono : MonoBehaviour, I_DroneGameShapeMetaInfoFeeder
{

    public DroneRCShapeMetaInfoMono m_toAffect;

    public Transform m_droneCenterReference;
    public Transform m_bladeOffsetFrontLeft;
    public Transform m_bladeOffsetFrontRight;
    public Transform m_bladeOffsetBackLeft;
    public Transform m_bladeOffsetBackRight;


    public Transform m_bladeFrontLeftHeightPoint;
    public Transform m_bladeFrontLeftRadiusPoint;

    public Transform m_bodyBoxCollider;
    public Transform m_bodyBoxColliderCornerFTR;


    [ContextMenu("Feed push shape info")]
    public void FeedPushInformation() {

       ExportDroneLocationUtility.GetWorldToLocal_Point( m_bladeOffsetFrontRight.position, m_droneCenterReference, out m_toAffect.m_shapeInfo.m_bladeOffsetFrontRight);
       ExportDroneLocationUtility.GetWorldToLocal_Point(m_bladeOffsetFrontLeft.position, m_droneCenterReference, out m_toAffect.m_shapeInfo.m_bladeOffsetFrontLeft);
       ExportDroneLocationUtility.GetWorldToLocal_Point(m_bladeOffsetBackRight.position, m_droneCenterReference, out m_toAffect.m_shapeInfo.m_bladeOffsetBackRight);
        ExportDroneLocationUtility.GetWorldToLocal_Point(m_bladeOffsetBackLeft.position, m_droneCenterReference, out m_toAffect.m_shapeInfo.m_bladeOffsetBackLeft);


        m_toAffect.m_shapeInfo.m_radiusOfBlade = Vector3.Distance(m_bladeFrontLeftRadiusPoint.position, m_bladeOffsetFrontLeft.position);
        m_toAffect.m_shapeInfo.m_heightOfBlade = Vector3.Distance(m_bladeFrontLeftHeightPoint.position, m_bladeOffsetFrontLeft.position)*2;

        ExportDroneLocationUtility.GetWorldToLocal_Point(m_bodyBoxCollider.position, m_droneCenterReference, out m_toAffect.m_shapeInfo.m_boxColliderOffset);

        m_toAffect.m_shapeInfo.m_heightOfBoxCollider = Mathf.Abs(m_bodyBoxCollider.position.y - m_bodyBoxColliderCornerFTR.position.y) * 2;
        m_toAffect.m_shapeInfo.m_widthOfBoxCollider = Mathf.Abs(m_bodyBoxCollider.position.x - m_bodyBoxColliderCornerFTR.position.x) * 2;
        m_toAffect.m_shapeInfo.m_depthOfBoxCollider = Mathf.Abs(m_bodyBoxCollider.position.z- m_bodyBoxColliderCornerFTR.position.z) * 2;
    }

   
}


public class ExportDroneLocationUtility {
    public static void GetWorldToLocal_Point(in Vector3 worldPosition, in Transform rootReference, out Vector3 localPosition)
    {
        Vector3 p = rootReference.position;
        Quaternion r = rootReference.rotation;
        GetWorldToLocal_Point(in worldPosition, in p, in r, out localPosition);
    }

    public static void GetWorldToLocal_Point(in Vector3 worldPosition, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 localPosition) =>
        localPosition = Quaternion.Inverse(rotationReference) * (worldPosition - positionReference);


}