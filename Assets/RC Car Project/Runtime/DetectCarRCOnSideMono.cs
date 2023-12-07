using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCarRCOnSideMono : MonoBehaviour
{

    public Transform m_carDirection;
    public bool m_isOnSide;

    public bool m_useDirtyDebug = true;
    public Rigidbody m_moveTheCarRig;
    public float m_detectAngle=5;
    public ForceMode m_forceType = ForceMode.Acceleration;
    public float m_upForce = 1;
    public float m_rotateAngle = 1;
    public float m_countDownToUnlock = 3;
    public float m_countDown = 0;

    void Update()
    {
        Vector3 rightDirection = m_carDirection.right;
        Vector3 leftDirection = -m_carDirection.right;
        Vector3 worldUp = Vector3.up;




        m_isOnSide = Vector3.Angle(rightDirection, worldUp) < m_detectAngle || Vector3.Angle(leftDirection, worldUp) < m_detectAngle;
        if (m_isOnSide && m_useDirtyDebug) {
            float previous = m_countDown;

            m_countDown += Time.deltaTime;
            if (previous < m_countDownToUnlock && m_countDown >= m_countDownToUnlock)
            {
                m_moveTheCarRig.AddTorque(new Vector3(Random.value, Random.value, Random.value)* m_rotateAngle, ForceMode.Impulse);
                m_moveTheCarRig.AddForce(Vector3.up * m_upForce , ForceMode.Impulse);
                m_countDown = 0;
            }
        }




    }
}
