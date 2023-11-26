using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConvertTankFourInputToArrowMono : MonoBehaviour
{
    public BooleanUnityEvent m_onUp;
    public BooleanUnityEvent m_onDown;
    public BooleanUnityEvent m_onLeft;
    public BooleanUnityEvent m_onRight;
    public bool m_leftForward;
    public bool m_leftBackward;
    public bool m_rightForward;
    public bool m_rightBackward;

    [Header("Debug only don't touch")]
    public bool m_up;
    public bool m_down;
    public bool m_left;
    public bool m_right;
    public bool m_upPrevious;
    public bool m_downPrevious;
    public bool m_leftPrevious;
    public bool m_rightPrevious;

    [System.Serializable]
    public class BooleanUnityEvent : UnityEvent<bool> { }

    private void Update()
    {
        RefreshAndTrigger();
    }
    
    public void RefreshAndTrigger()
    {

        m_upPrevious=    m_up;
        m_downPrevious=  m_down;
        m_leftPrevious=  m_left;
        m_rightPrevious= m_right;
        //Nothing
        if (m_leftForward && m_leftBackward && m_rightForward && m_rightBackward)
        {
            m_up = false; m_down = false; m_left = false; m_right = false;
        }
        //foward
        else if (m_leftForward && !m_leftBackward && m_rightForward && !m_rightBackward)
        {
            m_up = true; m_down = false; m_left = false; m_right = false;
        }//Backward
        else if (!m_leftForward && m_leftBackward && !m_rightForward && m_rightBackward)
        {
            m_up = false; m_down = true; m_left = false; m_right = false;
        }
        // Right
        else if (m_leftForward && !m_leftBackward && !m_rightForward && !m_rightBackward)
        {
            m_up = false; m_down = false; m_left = false; m_right = true;
        }  // Right
        else if (m_leftForward && !m_leftBackward && !m_rightForward && m_rightBackward)
        {
            m_up = false; m_down = false; m_left = false; m_right = true;
        }
        //Left
        else if (!m_leftForward && !m_leftBackward && m_rightForward && !m_rightBackward)
        {
            m_up = false; m_down = false; m_left = true; m_right = false;
        }
        else if (!m_leftForward && m_leftBackward && m_rightForward && !m_rightBackward)
        {
            m_up = false; m_down = false; m_left = true; m_right = false;
        }//Right from backward
        else if (!m_leftForward && !m_leftBackward && !m_rightForward && m_rightBackward)
        {
            m_up = false; m_down = false; m_left = false; m_right = true;
        }//Left from backward
        else if (!m_leftForward && m_leftBackward && !m_rightForward && !m_rightBackward)
        {
            m_up = false; m_down = false; m_left = true; m_right = false;
        }
        else {
            //Nothing
            m_up = false; m_down = false; m_left = false; m_right = false;
        }
        if (m_upPrevious != m_up) m_onUp.Invoke(m_up);
        if (m_downPrevious != m_down) m_onDown.Invoke(m_down);
        if (m_leftPrevious != m_left) m_onLeft.Invoke(m_left);
        if (m_rightPrevious != m_right) m_onRight.Invoke(m_right);

    }


    public void OnRightForward(bool stateIsOn)
    {
        m_rightForward = stateIsOn;
    }
    public void OnLeftForward(bool stateIsOn)
    {
        m_leftForward = stateIsOn;
    }
    public void OnRightBackward(bool stateIsOn)
    {
        m_rightBackward = stateIsOn;
    }
    public void OnLeftBackward(bool stateIsOn)
    {
        m_leftBackward = stateIsOn;
    }
}
