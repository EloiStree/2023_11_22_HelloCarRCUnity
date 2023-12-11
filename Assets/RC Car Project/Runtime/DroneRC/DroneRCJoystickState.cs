using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct DroneRCJoystickState
{
    public bool m_isPowerOn;
    public float m_horizontalLeft2Right;
    public float m_verticalDown2Up;
    public float m_frontalBack2Front;
    public float m_rotateLeft2Right;

}
