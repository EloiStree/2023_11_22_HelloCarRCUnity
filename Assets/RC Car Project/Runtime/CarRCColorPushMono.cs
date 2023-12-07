using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CarRCColorPushMono : MonoBehaviour
{
    public Color m_teamColor;
    public ColorEvent m_onPushColor;
    [System.Serializable]
    public class ColorEvent: UnityEvent <Color>{ }

    [ContextMenu("Push Color")]
    public void PushColor()
    {
        m_onPushColor.Invoke(m_teamColor);
    }
    [ContextMenu("Random Color")]
    public void RandomColor()
    {
        m_teamColor = new Color(Random.value, Random.value, Random.value, 1);
    }

    private void Reset()
    {
        RandomColor();
        PushColor();
    }

}
