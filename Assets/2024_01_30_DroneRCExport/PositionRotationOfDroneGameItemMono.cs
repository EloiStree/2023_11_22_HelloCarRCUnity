using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionRotationOfDroneGameItemMono : MonoBehaviour
{
    public Transform m_itemReference;

    public void GetPosition(out Vector3 position) => position = m_itemReference.position;
    public void GetRotation(out Quaternion rotation) => rotation = m_itemReference.rotation;
    public Transform GetTransform() { return m_itemReference; }

    private void Reset()
    {
        m_itemReference = transform;
    }
}
