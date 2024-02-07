using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRCShapeMetaInfoMono : MonoBehaviour
{
    public CarRCShapeMetaInfo m_shapeInfo;
}
[System.Serializable]
public class CarRCShapeMetaInfo {
    public Vector3 m_wheelOffsetFrontLeft;
    public Vector3 m_wheelOffsetFrontRight;
    public Vector3 m_wheelOffsetBackLeft;
    public Vector3 m_wheelOffsetBackRight;
    /// <summary>
    /// All the wheel has the same radius
    /// </summary>
    public float m_radiusOfWheels;
    /// <summary>
    ///  Height or depth is the size of the wheel between the body and the outside.
    /// </summary>
    public float m_heightOfWheels;

    // Collider represent the square defined by the wheels.
    // The car is inside the wheels as it must be able to flip.

    public Vector3 m_boxCarColliderOffset;
    public float m_heightOfCarCollider;
    public float m_widthOfCarCollider;
    public float m_depthOfCarCollider;

    public Vector3 m_boxCarBodyColliderOffset;
    public float m_heightOfCarBodyCollider;
    public float m_widthOfCarBodyCollider;
    public float m_depthOfCarBodyCollider;
}
