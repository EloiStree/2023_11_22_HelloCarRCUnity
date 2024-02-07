using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PushFlyingSnitchOnTouchMono : MonoBehaviour
{


    public LayerMask m_maskAllowed = ~0;
    public UnityEvent m_collisionDetected;

    public Transform m_snitchCenter;
    public Rigidbody m_rigToAffect;
    public ForceMode m_forceToUse = ForceMode.Impulse;
    public float m_intensity = 1f;

    
    void OnCollisionEnter(Collision collider)
    {
        if (IsInLayerLayerMask(collider.gameObject.layer, in m_maskAllowed))
        {
            m_collisionDetected.Invoke();
            Vector3 direction = m_snitchCenter.position - collider.contacts[0].point;
            m_rigToAffect.AddForce(direction * m_intensity, m_forceToUse);
        }

    }
    public static bool IsInLayerLayerMask(in int layer, in LayerMask layermask)
    {
        return layermask == (layermask | (1 << layer));
    }


}
