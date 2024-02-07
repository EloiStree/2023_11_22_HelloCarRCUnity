using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjectStringIdMono : MonoBehaviour
{
    public string m_guid;
    public GameObject m_linkedGameObject;
    private void Reset()
    {
        if (m_linkedGameObject == null)
            m_linkedGameObject = this.gameObject;
        m_guid = m_linkedGameObject.GetInstanceID().ToString();
    }
}
