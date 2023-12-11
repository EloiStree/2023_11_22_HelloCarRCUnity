using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDroneRCJoystickStateSplitMono : MonoBehaviour
{
    public StringUnityEvent m_onPlayerId;
    public FloatUnityEvent m_onHorizontalLeft2Right  ;
    public FloatUnityEvent m_onFrontalBack2Front  ;
    public FloatUnityEvent m_onVerticalDown2Up  ;
    public FloatUnityEvent m_onRotateLeft2Right;
        
     
    [System.Serializable]
    public class FloatUnityEvent : UnityEvent<float> { }
    [System.Serializable]
    public class StringUnityEvent : UnityEvent<string> { }
    public void Push(PlayerDroneRCJoystickState playerButtonState)
    {

        if (playerButtonState != null)
        {
            m_onPlayerId.Invoke(playerButtonState.m_playerId);
            m_onHorizontalLeft2Right.Invoke(playerButtonState.m_buttonStateOfPlayer.m_horizontalLeft2Right);
            m_onFrontalBack2Front.Invoke(playerButtonState.m_buttonStateOfPlayer.m_frontalBack2Front);
            m_onVerticalDown2Up.Invoke(playerButtonState.m_buttonStateOfPlayer.m_verticalDown2Up);
            m_onRotateLeft2Right.Invoke(playerButtonState.m_buttonStateOfPlayer.m_rotateLeft2Right);
        }
    }
}
