using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MemoryListMissingScriptMono : MonoBehaviour
{

    public MonoMemoryUnityFix[] m_listOfMissingScripts;
    [ ContextMenu("Refresh")]
    void Refresh()
    {
        m_listOfMissingScripts = GameObject.FindObjectsOfType<MonoMemoryUnityFix>().Where(k=>k.m_missingScriptDetected).ToArray();

    }

}
