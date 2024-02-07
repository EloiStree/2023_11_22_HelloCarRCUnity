using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArenaDroneGameCenterRootTag : MonoBehaviour
{
    public Transform m_centerReference;

    private void Reset()
    {
        m_centerReference = transform;
    }
}
