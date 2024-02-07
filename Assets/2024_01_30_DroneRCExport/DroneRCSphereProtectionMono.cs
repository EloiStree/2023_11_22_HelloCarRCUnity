using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRCSphereProtectionMono : MonoBehaviour
{

    public DroneRCSphereProtection m_shapeInfo;
}


[System.Serializable]
public class DroneRCSphereProtection {

    public bool m_hasSphereProtection;
    public float m_sphereRadius;
    public Vector3 m_sphereCenterOffset;
}
