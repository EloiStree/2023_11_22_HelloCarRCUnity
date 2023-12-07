using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarRC_ScoreBoardMono : MonoBehaviour
{
    public int m_roundWinPoint=5;
    public int m_pointBlue ;
    public int m_pointRed ;
    public int m_roundBlue ;
    public int m_roundRed  ;
    public IntEvent m_onPointBlue;
    public IntEvent m_onPointRed;
    public IntEvent m_onRoundBlue;
    public IntEvent m_onRoundRed;

    [System.Serializable]
    public class IntEvent: UnityEvent<int>{}

    public void PushAll() {
        m_onPointBlue  .Invoke(m_pointBlue);
        m_onPointRed   .Invoke(m_pointRed);
        m_onRoundBlue  .Invoke(m_roundBlue);
        m_onRoundRed   .Invoke(m_roundRed);
    }
    [ContextMenu("Reset All")]
    public void ResetAll() {
        m_pointBlue = 0;
        m_pointRed = 0;
        m_roundBlue = 0;
        m_roundRed = 0;
        PushAll();
    }

    [ContextMenu("AddPointToBlue ")]
    public void AddPointToBlue() { m_pointBlue++;CheckForRound(); PushAll(); }

    private void CheckForRound()
    {
        if (m_pointBlue >= m_roundWinPoint)
        {
            m_pointBlue = 0;
            AddRoundToBlue();
        }
        if (m_pointRed >= m_roundWinPoint)
        {
            m_pointRed = 0;
            AddRoundToRed();
        }
    }

    [ContextMenu("AddPointToRed ")]
    public void AddPointToRed() { m_pointRed++; CheckForRound(); PushAll(); }
    [ContextMenu("AddRoundToBlue ")]
    public void AddRoundToBlue()
    {
        m_roundBlue++;
        ResetPoints();
        PushAll();
    }

 

    [ContextMenu("AddRoundToRed ")]
    public void AddRoundToRed() {
        m_roundRed++;
        ResetPoints();

        PushAll();
    }


    private void ResetPoints()
    {
        m_pointBlue = 0;
        m_pointRed = 0;
    }
}
