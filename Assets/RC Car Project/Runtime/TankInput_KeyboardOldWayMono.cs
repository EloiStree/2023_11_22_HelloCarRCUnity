using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankInput_KeyboardOldWayMono : MonoBehaviour
{
    public KeyCode m_leftForward;
    public KeyCode m_leftBackward;
    public KeyCode m_rightForward;
    public KeyCode m_rightBackward;
    public BooleanUnityEvent m_onLeftForward;
    public BooleanUnityEvent m_onLeftBackward;
    public BooleanUnityEvent m_onRightForward;
    public BooleanUnityEvent m_onRightBackward;

    [System.Serializable]
    public class BooleanUnityEvent : UnityEvent<bool> { }

    void Update()
    {

        CheckButtonStateAndSendEvent(m_leftForward, m_onLeftForward);
        CheckButtonStateAndSendEvent(m_leftBackward, m_onLeftBackward);
        CheckButtonStateAndSendEvent(m_rightForward, m_onRightForward);
        CheckButtonStateAndSendEvent(m_rightBackward, m_onRightBackward);
    }

    public void CheckButtonStateAndSendEvent(KeyCode button, BooleanUnityEvent eventToSend ) {
        bool isDown = Input.GetKeyDown(button);
        bool isUp = Input.GetKeyUp(button);
        if (isDown)
            eventToSend.Invoke(true);
        if (isUp)
            eventToSend.Invoke(false);
    }
}
