using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDroneRCJoystickStateRelayMono : MonoBehaviour
{
    public PlayerDroneRCJoystickStateChanged m_onRelay;
    public void Push(PlayerDroneRCJoystickState playerJoysticksState) {

        m_onRelay.Invoke(playerJoysticksState);
    }
}