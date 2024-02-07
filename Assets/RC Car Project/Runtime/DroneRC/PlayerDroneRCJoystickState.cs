using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerDroneRCJoystickState
{
    public string m_playerId="";
    public DroneRCJoystickState m_buttonStateOfPlayer = new DroneRCJoystickState();

    public PlayerDroneRCJoystickState()
    {
    }

    public PlayerDroneRCJoystickState(string id, float rotationLeftRight, float downUp, float leftRight, float backFront)
    {
        this.m_playerId = id;
        this.m_buttonStateOfPlayer.m_rotateLeft2Right = rotationLeftRight;
        this.m_buttonStateOfPlayer.m_horizontalLeft2Right = leftRight;
        this.m_buttonStateOfPlayer.m_verticalDown2Up = downUp;
        this.m_buttonStateOfPlayer.m_frontalBack2Front = backFront;
    }
}

[System.Serializable]
public class PlayerDroneRCJoystickStateChanged : UnityEvent<PlayerDroneRCJoystickState> { }