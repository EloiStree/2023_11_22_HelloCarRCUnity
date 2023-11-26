using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class CarRCJoystickInputToBoolEvent : MonoBehaviour
{
    private CarRCJoystickInput controls;

    public BooleanUnityEvent m_onLeftForward    ;
    public BooleanUnityEvent m_onLeftBackward   ;
    public BooleanUnityEvent m_onRightForward   ;
    public BooleanUnityEvent m_onRightBackward  ;
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

    public void CheckForChange(ref bool target, InputAction.CallbackContext context) {
        SavePreviousState();
        target = context.ReadValueAsButton();
        CheckForModification();
    }

    private void Awake()
    {
        controls = new CarRCJoystickInput();
        controls.CarRCFourBoolAll.LeftForward.performed += (InputAction.CallbackContext context) => {
            CheckForChange(ref m_leftForward, context);
        };
        controls.CarRCFourBoolAll.LeftBackward.performed += (InputAction.CallbackContext context) => {
            CheckForChange(ref m_leftBackward, context);
        };
        controls.CarRCFourBoolAll.RightForward.performed += (InputAction.CallbackContext context) => {
            CheckForChange(ref m_rightForward, context);
        };
        controls.CarRCFourBoolAll.RightBackward.performed += (InputAction.CallbackContext context) => {
            CheckForChange(ref m_rightBackward, context);
        };
        controls.CarRCFourBoolAll.LeftForward.canceled += (InputAction.CallbackContext context) => {
            CheckForChange(ref m_leftForward, context);
        };
        controls.CarRCFourBoolAll.LeftBackward.canceled += (InputAction.CallbackContext context) => {
            CheckForChange(ref m_leftBackward, context);
        };
        controls.CarRCFourBoolAll.RightForward.canceled += (InputAction.CallbackContext context) => {
            CheckForChange(ref m_rightForward, context);
        };
        controls.CarRCFourBoolAll.RightBackward.canceled += (InputAction.CallbackContext context) => {
            CheckForChange(ref m_rightBackward, context);
        };
    }

    private void OnEnable()
    {
        controls.Enable();
       
    }

    private void CheckForModification()
    {
        if (m_leftForwardPrevious   !=m_leftForward  ) m_onLeftForward .  Invoke(m_leftForward);
        if (m_leftBackwardPrevious  !=m_leftBackward ) m_onLeftBackward .Invoke(m_leftBackward);
        if (m_rightForwardPrevious  !=m_rightForward ) m_onRightForward .Invoke(m_rightForward);
        if (m_rightBackwardPrevious != m_rightBackward) m_onRightBackward.Invoke(m_rightBackward);

    }

    private void SavePreviousState()
    {
        m_leftForwardPrevious   =   m_leftForward   ;
        m_leftBackwardPrevious   =  m_leftBackward  ;
        m_rightForwardPrevious   =  m_rightForward ;
        m_rightBackwardPrevious =   m_rightBackward;



    }

    private void OnDisable()
    {
        controls.Disable();
     }

  
}
