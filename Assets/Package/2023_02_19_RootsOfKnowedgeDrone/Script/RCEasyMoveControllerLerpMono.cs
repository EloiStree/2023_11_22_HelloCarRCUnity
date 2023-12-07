using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RCEasyMoveControllerLerpMono : MonoBehaviour
{

    public Vector3 m_distanceInMeterPerSeconds = new Vector3(0.5f, 0.2f, 0.8f);
    public Vector3 m_speedPerDirectionPercent = new Vector3(0.3f,0.3f,0.3f);
    public float m_horizontalAnglePerSeconds=90;
    public float m_rotationSpeedPercent = 0.3f;

    public Transform m_rootOfCurrentObject;

    public Vector3 m_directionUser;
    public Vector3 m_directionUserPrevious;
    public float m_rotateLeftRightUser;
    public float m_rotateLeftRightUserPrevious;

    public float m_lerpRotation=1f;
    public float m_lerpMove = 1f;

    public void Update() {


        m_rotateLeftRightUserPrevious = Mathf.Lerp(m_rotateLeftRightUserPrevious, m_rotateLeftRightUser, m_lerpRotation*Time.deltaTime);
        m_directionUserPrevious = Vector3.Lerp(m_directionUserPrevious, m_directionUser, m_lerpRotation * Time.deltaTime);

        float dt = Time.deltaTime;
        Vector3 move = Vector3.zero;
        Vector3 droneRot = m_rootOfCurrentObject.rotation.eulerAngles;
        droneRot.x = 0;
        Quaternion r = Quaternion.Euler(droneRot);
        move += Vector3.forward * m_distanceInMeterPerSeconds.z * dt * m_directionUserPrevious.z 
            * m_speedPerDirectionPercent.z;
        move += Vector3.up * m_distanceInMeterPerSeconds.y * dt * m_directionUserPrevious.y
            * m_speedPerDirectionPercent.y;
        move += Vector3.right * m_distanceInMeterPerSeconds.x * dt * m_directionUserPrevious.x
            * m_speedPerDirectionPercent.x;
        move = r * move;

        m_rootOfCurrentObject.position += move;


        m_rootOfCurrentObject.rotation = m_rootOfCurrentObject.rotation *
            Quaternion.Euler(0, m_horizontalAnglePerSeconds
            *dt* m_rotateLeftRightUserPrevious * m_rotationSpeedPercent, 0);
    }
    public void SetFrontalMove(float backForward)
    {
        m_directionUser.z = Mathf.Clamp(backForward, -1, 1);
    }

    public void SetHorizontalRotation(float rotateLeftRight)
    {
        m_rotateLeftRightUser = Mathf.Clamp(rotateLeftRight, -1, 1);
    }

    public void SetHorizontaMove(float leftRight)
    {
        m_directionUser.x = Mathf.Clamp(leftRight, -1, 1);
    }

    public void SetVerticalMove(float downUp)
    {
        m_directionUser.y = Mathf.Clamp(downUp,-1,1);
    }

    public void SetFrontalMoveSpeedPercent(float backForward)
    {
        m_speedPerDirectionPercent.z = Mathf.Clamp(backForward, -1, 1);
    }

    public void SetHorizontalRotationSpeedPercent(float rotateLeftRight)
    {
        m_rotationSpeedPercent = Mathf.Clamp(rotateLeftRight, -1, 1);
    }

    public void SetHorizontaMoveSpeedPercent(float leftRight)
    {
        m_speedPerDirectionPercent.x = Mathf.Clamp(leftRight, -1, 1);
    }

    public void SetVerticalMoveSpeedPercent(float downUp)
    {
        m_speedPerDirectionPercent.y = Mathf.Clamp(downUp, -1, 1);
    }


}
