using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GUIDGivenStringIdMono : MonoBehaviour
{
    public string m_guid;
    
    private void Reset()
    {
        m_guid = Guid.NewGuid().ToString();    
    }
}
