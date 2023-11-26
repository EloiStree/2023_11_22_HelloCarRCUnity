using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment_JoystickOldWayInput : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public bool m_joystick1Button1;
    public bool m_joystick2Button1;
    public bool m_joystick3Button1;
    public bool m_joystick4Button1;
    // Update is called once per frame
    void Update()
    {
        //m_joystick1Button1 = Input.GetButton("J1B1");
        //m_joystick2Button1 = Input.GetButton("J2B1");
        //m_joystick3Button1 = Input.GetButton("J3B1");
        //m_joystick4Button1 = Input.GetButton("J4B1");
        m_joystick1Button1 = Input.GetButton("joystick 1 button 3");
        m_joystick2Button1 = Input.GetButton("joystick 2 button 3");
        m_joystick3Button1 = Input.GetButton("joystick 3 button 3");
        m_joystick4Button1 = Input.GetButton("joystick 4 button 3");



    }
}
