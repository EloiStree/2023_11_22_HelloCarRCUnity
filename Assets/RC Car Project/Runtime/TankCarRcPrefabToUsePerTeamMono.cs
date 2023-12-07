using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankCarRcPrefabToUsePerTeamMono : MonoBehaviour
{
    public GameObject m_blueTeamBodyReference;
    public GameObject m_blueTeamWheelReference;
    public GameObject m_redTeamBodyReference;
    public GameObject m_redTeamWheelReference;
    public TankCarRcPrefabToUseMono [] m_blueTeamCars;
    public TankCarRcPrefabToUseMono [] m_redTeamCars;

    [ContextMenu("UpdateWithGivenReference")]
    public void UpdateWithGivenReference()
    {
        foreach (var item in m_blueTeamCars)
        {
            if (item != null)
            {
                item.m_bodyPrefab = m_blueTeamBodyReference;
                item.m_wheelPrefab = m_blueTeamWheelReference;
                item.UpdateCar();
            }
        }
        foreach (var item in m_redTeamCars)
        {
            if (item != null)
            {
                item.m_bodyPrefab = m_redTeamBodyReference;
                item.m_wheelPrefab = m_redTeamWheelReference;
                item.UpdateCar();
            }
        }
    }
}
