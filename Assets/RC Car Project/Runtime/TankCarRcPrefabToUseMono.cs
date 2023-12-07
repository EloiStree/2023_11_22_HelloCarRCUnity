using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TankCarRcPrefabToUseMono : MonoBehaviour
{
    public GameObject m_bodyPrefab;
    public GameObject m_wheelPrefab;
    public VolumeSize m_bodySize;
    public VolumeSize m_wheelSize;

    public Transform m_whereToCreateBody;
    public Transform [] m_whereToCreateWheel;

    public List<GameObject> m_created= new List<GameObject>();

    public UnityEvent m_hideBodyDebugIfPrefab;
    public UnityEvent m_hideWheelDebugIfPrefab;


    [System.Serializable]
    public class VolumeSize
    {
        public Transform m_root;
        public Transform m_upY;
       
        public Vector3 GetUnifiedByHeightSize()
        {
            return new Vector3(
                Vector3.Distance(m_root.position, m_upY.position)*2f,
                Vector3.Distance(m_root.position, m_upY.position) * 2f,
                Vector3.Distance(m_root.position, m_upY.position) * 2f);
        }
    }

    public bool m_autoUpdateAtAwake=true;
    public void Awake()
    {
        if (m_autoUpdateAtAwake)
            UpdateCar();
    }

    public void UpdateCar()
    {
        foreach (var item in m_created)
        {
            if (item != null)
                Destroy(item);
        }


        m_created.Clear();
        GameObject gamo=null;
        if (m_bodyPrefab) { 
            gamo = GameObject.Instantiate(m_bodyPrefab, null);
            gamo.transform.localScale = m_bodySize.GetUnifiedByHeightSize();
            gamo.transform.position =   m_whereToCreateBody.position;
            gamo.transform.rotation = m_whereToCreateBody.rotation;
            gamo.transform.parent = m_whereToCreateBody;
            m_created.Add(gamo);
        }
        if (m_wheelPrefab) { 
            foreach (var item in m_whereToCreateWheel)
            {
                if (item == null)
                    continue;
                gamo = GameObject.Instantiate(m_wheelPrefab, null);
                gamo.transform.localScale = m_wheelSize.GetUnifiedByHeightSize();
                gamo.transform.position = item.position;
                gamo.transform.rotation = item.rotation;
                gamo.transform.parent = item;
                m_created.Add(gamo);
            }
        }
        if (m_bodyPrefab != null)
            m_hideBodyDebugIfPrefab.Invoke();
        if (m_wheelPrefab != null)
            m_hideWheelDebugIfPrefab.Invoke();
    }
}
