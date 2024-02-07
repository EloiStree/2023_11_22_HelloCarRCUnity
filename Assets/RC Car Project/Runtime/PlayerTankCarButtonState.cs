using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerTankCarButtonState
{
    public string m_playerId="";
    public TankCarButtonState m_buttonStateOfPlayer = new TankCarButtonState();

    public PlayerTankCarButtonState()
    {
    }

    public PlayerTankCarButtonState(string id, bool topLeft, bool topRight, bool downleft, bool downRight)
    {
        this.m_playerId = id;
        this.m_buttonStateOfPlayer.m_leftForward = topLeft;
        this.m_buttonStateOfPlayer.m_rightForward = topRight;
        this.m_buttonStateOfPlayer.m_leftBackward  = downleft;
        this.m_buttonStateOfPlayer.m_rightBackward = downRight;
    }
}

[System.Serializable]
public class PlayerTankCarRCStateChanged : UnityEvent<PlayerTankCarButtonState> { }