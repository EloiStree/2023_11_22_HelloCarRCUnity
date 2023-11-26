using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerTankCarButtonStateSplitMono : MonoBehaviour
{
    public StringUnityEvent m_onPlayerId;
    public BooleanUnityEvent m_onLeftForward    ;
    public BooleanUnityEvent m_onLeftBackward   ;
    public BooleanUnityEvent m_onRightForward   ;
    public BooleanUnityEvent m_onRightBackward ;


    [System.Serializable]
    public class BooleanUnityEvent : UnityEvent<bool> { }
    [System.Serializable]
    public class StringUnityEvent : UnityEvent<string> { }
    public void Push(PlayerTankCarButtonState playerButtonState)
    {

        if (playerButtonState != null)
        {
            m_onPlayerId.Invoke(playerButtonState.m_playerId);
            m_onLeftForward.Invoke(playerButtonState.m_buttonStateOfPlayer.m_leftForward);
            m_onLeftBackward.Invoke(playerButtonState.m_buttonStateOfPlayer.m_leftBackward);
            m_onRightForward.Invoke(playerButtonState.m_buttonStateOfPlayer.m_rightForward);
            m_onRightBackward.Invoke(playerButtonState.m_buttonStateOfPlayer.m_rightBackward);


        }
    }
}
