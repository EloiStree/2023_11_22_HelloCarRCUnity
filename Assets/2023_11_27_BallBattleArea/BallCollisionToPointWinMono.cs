using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BallCollisionToPointWinMono : MonoBehaviour
{

    public UnityEvent m_pointToTeamRed;
    public UnityEvent m_pointToTeamBlue;
    public WinType m_winCondition= WinType.WinOnTouchOppositedTeam;
    public enum WinType { WinOnTouchSameTeam, WinOnTouchOppositedTeam}

    public void OnCollisionEnter(Collision collision)
    {
       
        BallCollisionToPointWinGoalMono touch = collision.gameObject.GetComponent<BallCollisionToPointWinGoalMono>();
        if (touch != null && touch.m_team == BallCollisionToPointWinGoalMono.TeamType.TeamRed)
        {
            if (m_winCondition == WinType.WinOnTouchSameTeam)
                m_pointToTeamRed.Invoke();
            else 
                m_pointToTeamBlue.Invoke();
        }
        if (touch != null && touch.m_team == BallCollisionToPointWinGoalMono.TeamType.TeamBlue)
        {

            if (m_winCondition == WinType.WinOnTouchSameTeam)
                m_pointToTeamBlue.Invoke();
            else 
                m_pointToTeamRed.Invoke();
        }
    }
}
