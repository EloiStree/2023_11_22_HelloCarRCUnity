using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GivenIdOfDroneGameItemMono : MonoBehaviour
{
    public string m_itemGivenId;
  
    public void SetGivenId(string valueOfId) => m_itemGivenId = valueOfId;
    public void SetGivenIdWithGameObject(GameObject target) => m_itemGivenId = ""+target.GetInstanceID();


}
