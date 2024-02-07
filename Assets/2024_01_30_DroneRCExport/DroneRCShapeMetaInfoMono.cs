using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRCShapeMetaInfoMono : MonoBehaviour
{
    public DroneRCShapeMetaInfo m_shapeInfo;
}
[System.Serializable]
public  class DroneRCShapeMetaInfo
{

    public Vector3 m_bladeOffsetFrontLeft;
    public Vector3 m_bladeOffsetFrontRight;
    public Vector3 m_bladeOffsetBackLeft;
    public Vector3 m_bladeOffsetBackRight;

    public float   m_radiusOfBlade;
    public float   m_heightOfBlade;

    public Vector3 m_boxColliderOffset;
    public float   m_heightOfBoxCollider;
    public float   m_widthOfBoxCollider;
    public float   m_depthOfBoxCollider;

}