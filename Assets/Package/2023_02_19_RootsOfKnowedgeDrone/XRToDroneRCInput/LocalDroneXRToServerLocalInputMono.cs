
using UnityEngine;
using UnityEngine.Events;

public class LocalDroneXRToServerLocalInputMono : MonoBehaviour
{

    public XRToDroneRCInput m_localDroneInput;
    public float m_leftRight;
    public float m_backFront;
    public float m_downUp;
    public float m_leftRightRotation;
    [Range(0, 1)]
    public float m_leftRightPercent = 1;
    [Range(0, 1)]
    public float m_backFrontPercent = 1;
    [Range(0, 1)]
    public float m_downUpPercent = 1;
    [Range(0, 1)]
    public float m_leftRightRotationPercent = 1;

    public FloatEvent m_leftRightEvent;
    public FloatEvent m_backFrontEvent;
    public FloatEvent m_downUpEvent;
    public FloatEvent m_leftRightRotationEvent;
    [System.Serializable]
    public class FloatEvent : UnityEvent<float> { }

    public void Start()
    {


        m_localDroneInput = new XRToDroneRCInput();
        m_localDroneInput.Enable();
        m_localDroneInput.XRToDroneRCFull.LeftRight.Enable();

        m_localDroneInput.XRToDroneRCFull.LeftRight.performed += (a) => { m_leftRight = a.ReadValue<float>() * m_leftRightPercent; m_leftRightEvent.Invoke(m_leftRight); };
        m_localDroneInput.XRToDroneRCFull.LeftRight.canceled += (a) => { m_leftRight = 0; m_leftRightEvent.Invoke(0); };

        m_localDroneInput.XRToDroneRCFull.BackFront.performed += (a) => { m_backFront = a.ReadValue<float>() * m_backFrontPercent; m_backFrontEvent.Invoke(m_backFront); };
        m_localDroneInput.XRToDroneRCFull.BackFront.canceled += (a) => { m_backFront = 0; m_backFrontEvent.Invoke(0); };

        m_localDroneInput.XRToDroneRCFull.DownUp.performed += (a) => { m_downUp = a.ReadValue<float>() * m_downUpPercent; m_downUpEvent.Invoke(m_downUp); };
        m_localDroneInput.XRToDroneRCFull.DownUp.canceled += (a) => { m_downUp = 0; m_downUpEvent.Invoke(0); };

        m_localDroneInput.XRToDroneRCFull.LeftRigthRotation.performed += (a) => { m_leftRightRotation = a.ReadValue<float>() * m_leftRightRotationPercent; m_leftRightRotationEvent.Invoke(m_leftRightRotation); };
        m_localDroneInput.XRToDroneRCFull.LeftRigthRotation.canceled += (a) => { m_leftRightRotation = 0; m_leftRightRotationEvent.Invoke(0); };

    }

    public void SetSpeedModeGlobal(float speedPercent)
    {
        m_leftRightRotationPercent = speedPercent;
        m_downUpPercent = speedPercent;
        m_backFrontPercent = speedPercent;
        m_leftRightPercent = speedPercent;
    }

}