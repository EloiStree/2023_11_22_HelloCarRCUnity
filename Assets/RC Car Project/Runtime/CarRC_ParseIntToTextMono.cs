using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarRC_ParseIntToTextMono : MonoBehaviour
{
    public StringEvent m_onTextConverted;

    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }

    public void PushInt(int value)
    {
        m_onTextConverted.Invoke(""+value);
    }
    

}
