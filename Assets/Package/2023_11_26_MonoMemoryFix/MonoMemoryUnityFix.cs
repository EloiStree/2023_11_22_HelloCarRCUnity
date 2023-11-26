using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class MonoMemoryUnityFix : MonoBehaviour
{
    public List<ScriptMemoryRef> m_memoryReference= new();
     IEnumerable< MonoBehaviour> m_nearScript;
    public bool m_missingScriptDetected;

    [System.Serializable]
    public class ScriptMemoryRef {
        public string m_nearScriptName;
        public MonoBehaviour m_nearScript;

        public ScriptMemoryRef(string nearScriptName, MonoBehaviour nearScript)
        {
            m_nearScriptName = nearScriptName;
            m_nearScript = nearScript;
        }
    }

    [ContextMenu("Add Refresh Memory to all")]
    public void AddMemoryScriptToAllAndRefresh() {
        GameObject [] objects=  GameObject.FindObjectsOfType<GameObject>();
        //objects = objects.Where(k => k != null && k.GetType() != typeof(MonoMemoryUnityFix)).ToArray();
        foreach (var item in objects)
        {
            MonoMemoryUnityFix memoryScript = item.GetComponent<MonoMemoryUnityFix>();
            if(memoryScript==null)
                memoryScript = item.AddComponent<MonoMemoryUnityFix>();
            memoryScript.RefreshScriptAssocated();
        }
    }

    [ContextMenu("Refresh")]
    public void RefreshScriptAssocated() {

        m_memoryReference.Clear(); 
        m_missingScriptDetected = false;
         m_nearScript =  this.transform.GetComponents<MonoBehaviour>();
        if (m_nearScript != null) {
            foreach (var item in m_nearScript)
            {
                if (item == null)
                    m_missingScriptDetected = true;
            }
            m_nearScript = m_nearScript.Where(k => k!=null && k.GetType() != typeof(MonoMemoryUnityFix)).ToArray();
            if (m_nearScript != null) { 
                foreach (var item in m_nearScript)
                {
                    if (item != null)
                    {
                        m_memoryReference.Add(new ScriptMemoryRef(GetAssemblyInformation(item.GetType(), item.GetType().ToString()), item));
                    }
                    else {
                        m_missingScriptDetected = true;
                    }
                }
            }
        }
        else
        {
            m_missingScriptDetected = true;
        }
    }
    static string GetAssemblyInformation(Type type, string name)
    {
        // Get the assembly that contains the specified type
        Assembly assembly = type.Assembly;

        // Get various pieces of assembly information
        string assemblyName = assembly.GetName().Name;
        string version = assembly.GetName().Version.ToString();
        string location = assembly.Location;

        string assemblyInfo = $"{name} - {assemblyName}\n";

        return assemblyInfo;
    }

    private void Reset()
    {
        RefreshScriptAssocated();

    }
}
