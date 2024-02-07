using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScraperLog_BasicMatchstateSetPointsMono : AbstractCoroutineScraperLogMono
{
    public int m_setBlue;
    public int m_setRed;
    public int m_pointRed;
    public int m_pointBlue;

    public override void Push()
    {
        GetBroadcaster().Push_GameScore(m_setBlue, m_setRed, m_pointRed, m_pointBlue);
    }
}
