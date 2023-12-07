using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCarRCMono : MonoBehaviour
{

    public Transform m_whatToMove;
    public float m_timepast;
    public float m_carSpeedPerSecond = 0.3f;
    public float m_rotationPerSecondAsAngle = 180f;

    public bool m_makeCarMoveForward;
    public bool m_makeCarMoveBackward;
    public bool m_makeCarRotateLeft;
    public bool m_makeCarRotateRigh;

    void Start()
    {
        Debug.Log("Bonjour");
    }

    void Update()
    {
        float timePast = Time.deltaTime;
        m_timepast = timePast;
        Vector3 whereIsTheCar = m_whatToMove.position;
        Vector3 carForward = m_whatToMove.forward;
        if (m_makeCarMoveForward)
        {
            whereIsTheCar = whereIsTheCar + (carForward * timePast * m_carSpeedPerSecond);
        }
        if (m_makeCarMoveBackward)
        {
            whereIsTheCar = whereIsTheCar - (carForward * timePast * m_carSpeedPerSecond);
        }
        m_whatToMove.position = whereIsTheCar;

        //Quaternion rotation = m_whatToMove.rotation;
        //Quaternion rotatePerSecond = Quaternion.Euler(180f * timePast, 0,0) ;
        Vector3 angleToRotate = new Vector3(0 ,  -m_rotationPerSecondAsAngle * timePast, 0);
        if (m_makeCarRotateLeft)
        {
            m_whatToMove.Rotate(angleToRotate, Space.Self);
        }
        if (m_makeCarRotateRigh)
        {
            m_whatToMove.Rotate(-angleToRotate, Space.Self);
        }

    }

    public void ResetToNotMoving()
    {
        m_makeCarRotateRigh = false;
        m_makeCarRotateLeft = false;
        m_makeCarMoveBackward = false;
        m_makeCarMoveForward = false;
    }

    public void SetCarMoveForward(bool stateOfTheButtonIsOn) {

        m_makeCarMoveForward = stateOfTheButtonIsOn;
    }
    public void SetCarMoveBackward(bool stateOfTheButtonIsOn) { 
        m_makeCarMoveBackward= stateOfTheButtonIsOn;
    }
    public void SetCarRotationLeft(bool stateOfTheButtonIsOn) { 
        m_makeCarRotateLeft= stateOfTheButtonIsOn;
    }
    public void SetCarRotationRight(bool stateOfTheButtonIsOn) {
        m_makeCarRotateRigh= stateOfTheButtonIsOn; 
    }
}
