using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarRCColorToMeshColorMono : MonoBehaviour
{

    public Renderer[] m_toAffect;
    public void PushColor(Color color)
    {
        foreach (var item in m_toAffect)
        {
            if (item != null)
                item.material.color = color;
        }
    }

    private void Reset()
    {
        FindMeshNearScript();
    }

    private void FindMeshNearScript()
    {
        m_toAffect = this.gameObject.GetComponents<Renderer>();
    }
}
