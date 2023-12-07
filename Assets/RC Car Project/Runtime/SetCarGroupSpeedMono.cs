using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCarGroupSpeedMono : MonoBehaviour
{
    public CarToSpeed[] m_carsGroup = new CarToSpeed[] {
    new CarToSpeed (){ m_description= "Big One",m_timeToMakeFullTurn=8f},
    new CarToSpeed (){ m_description= "Medium One",m_timeToMakeFullTurn=4f},
    new CarToSpeed (){ m_description= "Small One",m_timeToMakeFullTurn=1.5f}
    };

    [System.Serializable]
    public class CarToSpeed
    {
        public string m_description;
        public float m_timeToMakeFullTurn = 1.5f;
        public float m_rotationRatioControl = 1;
        public GameObject[] m_cars;
    }

    void Start()
    {
        if(enabled)
            Refresh();
    }

    [ContextMenu("Refresh")]
    public void Refresh()
    {
        foreach (var g in m_carsGroup)
        {
            foreach (var c in g.m_cars)
            {
                ExostCarRCDefaultMono ex = c.GetComponentInChildren<ExostCarRCDefaultMono>();
                if (ex != null) { 
                    ex.SetTimeToMakeFullTurnAroundPivot(g.m_timeToMakeFullTurn);
                    ex.m_turnRatioControl = g.m_rotationRatioControl;
                }
            }
        }
    }
}
