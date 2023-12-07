using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneRCHeliceSpineMono : MonoBehaviour
{

    public Transform m_whatToRotate;
    public Vector3 m_localRotationAngle= Vector3.up;
    public float m_heliceSpeed=180;
    public bool m_inverse;
    [Range(0, 1f)]
    public float m_percentPower = 1f;

    private void Update()
    {
        m_whatToRotate.Rotate(m_localRotationAngle, m_heliceSpeed * Time.deltaTime * (m_inverse ? -1f : 1f)* m_percentPower, Space.Self);
    }
    void Reset()
    {
        m_whatToRotate
             = transform;
    }
}
