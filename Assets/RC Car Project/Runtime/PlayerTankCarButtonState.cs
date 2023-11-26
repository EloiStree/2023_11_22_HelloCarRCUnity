using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]
public class PlayerTankCarButtonState
{
    public string m_playerId="";
    public TankCarButtonState m_buttonStateOfPlayer = new TankCarButtonState();
}

[System.Serializable]
public class PlayerTankCarRCStateChanged : UnityEvent<PlayerTankCarButtonState> { }