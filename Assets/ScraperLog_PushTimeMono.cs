using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScraperLog_PushTimeMono : AbstractCoroutineScraperLogMono
{
   
    private IEnumerator Start()
    {
        while (true) {
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(m_timeBetweenPush);
            if (m_useCoroutinetoPushTime) {
                Push();
            }
        }
    }
    public override void Push() {
        GetBroadcaster().Push_TimeTick();
    }
}


public abstract class AbstractScraperLogMono : MonoBehaviour
{
    [SerializeField] ScrapeGameLogBroadcasterMono m_broadcaster;
    public ScrapeGameLogBroadcasterMono GetBroadcaster() { return m_broadcaster; }
    public abstract void Push();

    public void Reset()
    {
        m_broadcaster = this.GetComponent<ScrapeGameLogBroadcasterMono>();
    }
}


public abstract class AbstractCoroutineScraperLogMono : AbstractScraperLogMono
{
    public bool m_pause;
    public bool m_useCoroutinetoPushTime = true;
    public float m_timeBetweenPush = 1;


    private IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            yield return new WaitForSeconds(m_timeBetweenPush);
            if (m_useCoroutinetoPushTime)
            {
                if (!m_pause)
                { 
                    Push();
                }
            }
        }
    }
    
}