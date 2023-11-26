using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTankCarButtonStateRelayMono : MonoBehaviour
{
    public PlayerTankCarRCStateChanged m_onRelay;
    public void Push(PlayerTankCarButtonState playerButtonState) {

        m_onRelay.Invoke(playerButtonState);
    }
}
