using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ConvertArrowToTankFourInputMono : MonoBehaviour
{
    public BooleanUnityEvent m_onLeftForward;
    public BooleanUnityEvent m_onLeftBackward;
    public BooleanUnityEvent m_onRightForward;
    public BooleanUnityEvent m_onRightBackward;

    [Header("Debug only don't touch")]
    public bool m_up;
    public bool m_down;
    public bool m_left;
    public bool m_right;

    public bool m_leftForward;
    public bool m_leftBackward;
    public bool m_rightForward;
    public bool m_rightBackward;
    public bool m_leftForwardPrevious;
    public bool m_leftBackwardPrevious;
    public bool m_rightForwardPrevious;
    public bool m_rightBackwardPrevious;


    [System.Serializable]
    public class BooleanUnityEvent : UnityEvent<bool> { }

    private void Update()
    {
        RefreshAndTrigger();
    }

    public void RefreshAndTrigger()
    {

       m_leftForwardPrevious=       m_leftForward;
       m_leftBackwardPrevious=      m_leftBackward;
       m_rightForwardPrevious=      m_rightForward;
        m_rightBackwardPrevious=    m_rightBackward;
        //Nothing

          if (m_left == true && m_right == false)
        {
            m_leftForward = true;
            m_rightForward = false;
            m_leftBackward = false;
            m_rightBackward = false;
        }
        else if (m_left == false && m_right == true)
        {
            m_leftForward = false;
            m_rightForward = true;
            m_leftBackward = false;
            m_rightBackward = false;
        }
        else if(m_up == true && m_down == false)
        {
            m_leftForward=true;
            m_rightForward=true;
            m_leftBackward=false;
            m_rightBackward=false;
        }
        else if (m_up == false && m_down == true)
        {
            m_leftForward = false;
            m_rightForward = false;
            m_leftBackward = true;
            m_rightBackward = true;
        }

       
        else
        {
            //Nothing
            m_leftForward = false;
            m_leftBackward = false;
            m_rightForward = false;
            m_rightBackward = false;
        }
        if (m_leftForwardPrevious   ) m_onLeftForward.Invoke(m_leftForward);
        if (m_leftBackwardPrevious  ) m_onLeftBackward.Invoke(m_leftBackward);
        if (m_rightForwardPrevious  ) m_onRightForward.Invoke(m_rightForward);
        if (m_rightBackwardPrevious ) m_onRightBackward.Invoke(m_rightBackward);



    }


    public void SetAsForward(bool stateIsOn)
    {
        m_up = stateIsOn;
    }
    public void SetAsBackward(bool stateIsOn)
    {
        m_down = stateIsOn;
    }
    public void SetAsLeft(bool stateIsOn)
    {
        m_left = stateIsOn;
    }
    public void SetAsRight(bool stateIsOn)
    {
        m_right = stateIsOn;
    }
}
