using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ArrowInputType_KeyboardOldWayMono : MonoBehaviour { 


    public KeyCode m_up= KeyCode.UpArrow;
    public KeyCode m_down= KeyCode.DownArrow;
    public KeyCode m_left= KeyCode.LeftArrow;
    public KeyCode m_right= KeyCode.RightArrow;
    public BooleanUnityEvent m_onUp;
    public BooleanUnityEvent m_onDown;
    public BooleanUnityEvent m_onLeft;
    public BooleanUnityEvent m_onRight;

    [System.Serializable]
    public class BooleanUnityEvent : UnityEvent<bool> { }

    void Update()
    {

        CheckButtonStateAndSendEvent(m_up, m_onUp);
        CheckButtonStateAndSendEvent(m_down, m_onDown);
        CheckButtonStateAndSendEvent(m_left, m_onLeft);
        CheckButtonStateAndSendEvent(m_right, m_onRight);
    }

    public void CheckButtonStateAndSendEvent(KeyCode button, BooleanUnityEvent eventToSend)
    {
        bool isDown = Input.GetKeyDown(button);
        bool isUp = Input.GetKeyUp(button);
        if (isDown)
            eventToSend.Invoke(true);
        if (isUp)
            eventToSend.Invoke(false);
    }
}
