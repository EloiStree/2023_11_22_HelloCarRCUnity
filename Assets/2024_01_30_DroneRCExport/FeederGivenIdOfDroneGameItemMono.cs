using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeederGivenIdOfDroneGameItemMono : MonoBehaviour, I_DroneGameShapeMetaInfoFeeder
{
    public GivenIdOfDroneGameItemMono m_toAffect;
    public GameObject m_idRootObject;

    [ContextMenu("Feed push shape info")]
    public void FeedPushInformation()
    {
        m_toAffect.SetGivenId(m_idRootObject.GetInstanceID().ToString());
    }


}
