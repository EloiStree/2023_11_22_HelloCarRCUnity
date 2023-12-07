using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetColorOrMeshColor : MonoBehaviour
{
    public MeshRenderer[] m_mesh;

    public void SetWithColor(Color color) {
        for (int i = 0; i < m_mesh.Length; i++)
        {
            if(m_mesh[i]!=null)
            m_mesh[i].material.color = color;
        }
    }
   
}
