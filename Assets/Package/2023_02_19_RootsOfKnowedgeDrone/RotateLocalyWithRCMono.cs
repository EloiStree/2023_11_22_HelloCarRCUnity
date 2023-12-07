using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateLocalyWithRCMono : MonoBehaviour
{

    public Transform m_toRotate;
    public Transform m_origineToRotate;

    public float m_maxAnglePitchBackFront=15f;
    public float m_maxAngleRollLefRight=15f;



    public float m_rollUserLerped;
    public float m_pitchUserLerped;

    public float m_lerpValue=1;
    public float m_rollUser;
    public float m_pitchUser;

    public void SetRollRC(float rcValue)
    {
        m_rollUser = rcValue;
    }
    public void SetPitchRC(float rcValue)
    {

        m_pitchUser = rcValue;
    }



    void Update()
    {
        m_rollUserLerped = Mathf.Lerp(m_rollUserLerped, m_rollUser, Time.deltaTime* m_lerpValue);
        m_pitchUserLerped = Mathf.Lerp(m_pitchUserLerped, m_pitchUser, Time.deltaTime* m_lerpValue);

        m_toRotate .rotation = m_origineToRotate.rotation * Quaternion.Euler(m_pitchUserLerped * m_maxAnglePitchBackFront, 0, -m_rollUserLerped * m_maxAngleRollLefRight);

    }
}
