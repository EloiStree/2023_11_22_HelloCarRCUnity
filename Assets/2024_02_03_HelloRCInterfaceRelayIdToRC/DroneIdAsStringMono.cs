using UnityEngine;

public class DroneIdAsStringMono : MonoBehaviour, I_HasDroneIDAsString
{

    public string m_droneStringId;

    public string GetDroneIDAsString()
    {
        return m_droneStringId;
    }
}
