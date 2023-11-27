using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallCollisionToPointWinMono : MonoBehaviour
{

    public UnityEvent m_pointToTeamRed;
    public UnityEvent m_pointToTeamBlue;


    public void OnCollisionEnter(Collision collision)
    {
       
        BallCollisionToPointWinGoalMono touch = collision.gameObject.GetComponent<BallCollisionToPointWinGoalMono>();
        if (touch != null && touch.m_team == BallCollisionToPointWinGoalMono.TeamType.TeamRed)
        {
            m_pointToTeamRed.Invoke();
        }
        if (touch != null && touch.m_team == BallCollisionToPointWinGoalMono.TeamType.TeamBlue)
        {

            m_pointToTeamBlue.Invoke();
        }
    }
}
