using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AskFeederInGameToComputeMono : MonoBehaviour
{
    
    public static List<I_DroneGameShapeMetaInfoFeeder>
        feeders= new List<I_DroneGameShapeMetaInfoFeeder>();

    public bool m_feedAtAwake;

    public void Awake()
    {
        if(m_feedAtAwake)
            Feed();
    }

    public void CallFeedFromMono() => Feed();

    public static void Feed()
    {
        GatherFeeders();
        PushFeed();
    }

    private static void PushFeed()
    {
        foreach (var f in feeders)
        {
            if (f!=null) {
                try {
                    f.FeedPushInformation();
                }
                catch (Exception e) {
                    Debug.Log("E " + e.StackTrace);
                }
            }
        }
    }

    private static void GatherFeeders()
    {
        feeders.Clear();
        MonoBehaviour[] f =
            GameObject.FindObjectsByType<MonoBehaviour>
            (FindObjectsSortMode.None);

        foreach (var mono in f)
        {
            if (mono != null && mono is I_DroneGameShapeMetaInfoFeeder)
                feeders.Add((I_DroneGameShapeMetaInfoFeeder)mono);
        }
    }
}
