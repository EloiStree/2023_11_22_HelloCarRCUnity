using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RelayFourBoolRCOnlyChangeMono : MonoBehaviour
{
    public BooleanUnityEvent m_onLeftForward;
    public BooleanUnityEvent m_onLeftBackward;
    public BooleanUnityEvent m_onRightForward;
    public BooleanUnityEvent m_onRightBackward;

    public bool m_leftForward;
    public bool m_leftBackward;
    public bool m_rightForward;
    public bool m_rightBackward;

    public bool m_leftForwardPrevious;
    public bool m_leftBackwardPrevious;
    public bool m_rightForwardPrevious;
    public bool m_rightBackwardPrevious;


    public void SetLeftForward(bool isStateOn)
    {
        SavePreviousState();
        m_leftForward = isStateOn;
        CheckForModification();
    }
    public void SetLeftBackward(bool isStateOn)
    {
        SavePreviousState();
        m_leftBackward = isStateOn;
        CheckForModification();
    }
    public void SetRightForward(bool isStateOn)
    {
        SavePreviousState();
        m_rightForward = isStateOn;
        CheckForModification();
    }
    public void SetRightBackward(bool isStateOn)
    {
        SavePreviousState();
        m_rightBackward = isStateOn;
        CheckForModification();
    }

    [System.Serializable]
    public class BooleanUnityEvent : UnityEvent<bool> { }
    private void CheckForModification()
    {
        if (m_leftForwardPrevious != m_leftForward) m_onLeftForward.Invoke(m_leftForward);
        if (m_leftBackwardPrevious != m_leftBackward) m_onLeftBackward.Invoke(m_leftBackward);
        if (m_rightForwardPrevious != m_rightForward) m_onRightForward.Invoke(m_rightForward);
        if (m_rightBackwardPrevious != m_rightBackward) m_onRightBackward.Invoke(m_rightBackward);

    }

    private void SavePreviousState()
    {
        m_leftForwardPrevious = m_leftForward;
        m_leftBackwardPrevious = m_leftBackward;
        m_rightForwardPrevious = m_rightForward;
        m_rightBackwardPrevious = m_rightBackward;

    }
}
