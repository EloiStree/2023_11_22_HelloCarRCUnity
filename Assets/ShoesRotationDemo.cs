using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoesRotationDemo : MonoBehaviour
{
    public int m_age = 13;
    public Transform m_whatToMove;
    public float m_speed= 1;
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("Bonjour");
        InvokeRepeating("Salut", 0, 1);
    }

    // Update is called once per frame
    void Salut()
    {
        Debug.Log("Salut !");

    }

    private void Update()
    {
        float timePast =Time.deltaTime;
        m_whatToMove.Translate(0, 0, 1 * timePast * m_speed, Space.Self);


    }
}
