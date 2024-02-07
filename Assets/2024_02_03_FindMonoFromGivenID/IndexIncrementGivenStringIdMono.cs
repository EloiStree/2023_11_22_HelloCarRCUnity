using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IndexIncrementGivenStringIdMono : MonoBehaviour
{
    public static int GetUniqueIndex() { GlobalIndex++; return GlobalIndex; }
    static int GlobalIndex=0;
    
    public string m_uniqueId;
    public bool m_useAwakeToClaimIndex=true;

    void Awake()
    {
        if (m_useAwakeToClaimIndex) {
            m_uniqueId = GetUniqueIndex().ToString();
            SetGivenId(m_uniqueId, this);
        }
    }

    private static void SetGivenId(string uniqueId, IndexIncrementGivenStringIdMono script)
    {
        if (!m_inScene.ContainsKey(uniqueId))
            m_inScene.Add(uniqueId, script);
        else m_inScene[uniqueId]=script;
    }

    public static Dictionary<string, IndexIncrementGivenStringIdMono> m_inScene = new Dictionary<string, IndexIncrementGivenStringIdMono>();



}
