using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class NamedBooleanToEventRelayMono : MonoBehaviour
{



    public NamedIdToBooleanEvent [] m_relay;
    [System.Serializable]
    public class NamedIdToBooleanEvent {
        public string m_namedId;
        public BoolEvent m_onBooleanEvent;
    
    }

    [System.Serializable]
    public class BoolEvent : UnityEvent<bool> { }

    public void Push(string booleanNamed, bool booleanValue) {

        foreach (var item in m_relay.Where(K=>K.m_namedId.Trim().ToLower()== booleanNamed.Trim().ToLower()))
        {
            item.m_onBooleanEvent.Invoke(booleanValue);
        }
    }
}
