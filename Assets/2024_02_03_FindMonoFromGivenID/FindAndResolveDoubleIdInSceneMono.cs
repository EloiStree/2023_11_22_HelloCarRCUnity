using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FindAndResolveDoubleIdInSceneMono : MonoBehaviour
{


    public Dictionary<string,List< GameObject>> m_allId = new Dictionary<string, List<GameObject>>();

    public List<IDWithDouble> m_doubles = new List<IDWithDouble>();
    public Dictionary<string, ShortGivenStringIdMono> m_shortIdInGame = new Dictionary<string,ShortGivenStringIdMono>();

    public static T GetComponentInParentOrItself<T>(GameObject gameObject)
    {
        T c = gameObject.GetComponentInParent<T>();
        if (c != null) return c;
        return gameObject.GetComponent<T>();
    }

    public string[] m_keys = new string[0];

    public static T GetComponentInChildrenOrItself<T>(GameObject gameObject)
    {
        T c = gameObject.GetComponentInChildren<T>();
        if (c != null) return c;
        return gameObject.GetComponent<T>();
    }

    [System.Serializable]
    public class IDWithDouble
    {
        public string m_id="";
        public List<GameObject> m_objects= new List<GameObject>();

        public IDWithDouble(string id, List<GameObject> objects)
        {
            m_id = id;
            m_objects = objects;
        }
    }
    public GameObject[] m_allObjects;
    [ContextMenu("Find All Object Active In Scene")]
    public void FindAllObjectActiveInScene() {
        m_allId.Clear();
         m_allObjects = GameObject.FindObjectsByType<GameObject>(FindObjectsSortMode.None);
        foreach (var item in m_allObjects)
        {
            GUIDGivenStringIdMono guid = item.GetComponent<GUIDGivenStringIdMono>();
            if (guid != null) Add(guid.m_guid, item.gameObject);
            ShortGivenStringIdMono guid1 = item.GetComponent<ShortGivenStringIdMono>();
            if (guid1 != null) {
                if (!m_shortIdInGame.ContainsKey(guid1.m_shortId))
                    m_shortIdInGame[guid1.m_shortId] = guid1;
                Add(guid1.m_shortId, item.gameObject);
            }

            GameObjectStringIdMono guid3 = item.GetComponent<GameObjectStringIdMono>();
            if (guid3 != null) Add(guid3.m_guid, item.gameObject);

            LabelGivenStringIdMono guid2 = item.GetComponent<LabelGivenStringIdMono>();
            if (guid2 != null) {
                foreach (var g in guid2.m_givenLabels)
                {
                    Add(g, item.gameObject);
                }
            }
        }

        m_doubles.Clear();
        foreach (var item in m_allId.Keys)
        {
            if (m_allId[item].Count > 1) {
                m_doubles.Add(new IDWithDouble(item, m_allId[item]));
            }
        }

        m_keys = m_allId.Keys.OrderBy(k => k).ToArray();

    }

    private void Add(string stringId, GameObject item)
    {
        if (!m_allId.ContainsKey(stringId))
            m_allId.Add(stringId, new List<GameObject>());
        m_allId[stringId].Add(item);
    }

    public void GetKey(string key, out bool found, out GameObject target) {
        
        found = false;
        target = null;
        if (m_allId.ContainsKey(key)) { 
            List<GameObject> obs = m_allId[key];
            if (obs.Count > 0) {
                found = true;
                target = obs[0];
            
            }
        }

    }
}
