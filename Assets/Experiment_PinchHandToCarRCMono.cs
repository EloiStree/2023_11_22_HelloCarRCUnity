using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Experiment_PinchHandToCarRCMono : MonoBehaviour
{
    public Transform m_pointA;
    public Transform m_pointB;
    public float m_distanceToPinch=0.03f;
    public bool m_isPinching;
    public BoolEvent m_onBoolChanged;

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    
    void Update()
    {
        if (m_pointA.gameObject.activeInHierarchy && m_pointB.gameObject.activeInHierarchy) { 
            bool isPinching = Vector3.Distance(m_pointA.position, m_pointB.position)<m_distanceToPinch;
            if (isPinching != m_isPinching) {
                m_isPinching = isPinching;
                m_onBoolChanged.Invoke(isPinching);
            }
        }
        
    }
}
