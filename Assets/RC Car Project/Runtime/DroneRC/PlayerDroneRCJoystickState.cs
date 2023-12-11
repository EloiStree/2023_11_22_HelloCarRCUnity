using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerDroneRCJoystickState
{
    public string m_playerId="";
    public DroneRCJoystickState m_buttonStateOfPlayer = new DroneRCJoystickState();
}

[System.Serializable]
public class PlayerDroneRCJoystickStateChanged : UnityEvent<PlayerDroneRCJoystickState> { }