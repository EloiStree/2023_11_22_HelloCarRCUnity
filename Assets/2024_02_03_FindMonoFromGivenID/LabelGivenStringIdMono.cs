using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LabelGivenStringIdMono : MonoBehaviour
{
    public string [] m_givenLabels;

    private void Reset()
    {
        GenerateGivenLabels();
    }

    private void GenerateGivenLabels()
    {
        m_givenLabels = new string[] {
        "No label",
        GenerateRandomIdStringUtility.GenerateIdLetter(6),
        GenerateRandomIdStringUtility.GUID()
        };
    }
    [ContextMenu("Reset to no label")]
    private void ResetToNoLabel()
    {
        m_givenLabels = new string[] {
        "No label"
        
        };
    }
}
