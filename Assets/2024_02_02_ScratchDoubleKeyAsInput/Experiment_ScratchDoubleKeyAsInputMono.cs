using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment_ScratchDoubleKeyAsInputMono : MonoBehaviour
{
    public string m_idTarget = "Red Car 1";
    public FindAndResolveDoubleIdInSceneMono m_idInScene;
    public GameObject m_idTargetGameObject; 
    public DroneGameItemRootTag m_idTargetRoot;
    public PlayerTankCarButtonStateRelayMono relayCar;
    public PlayerDroneRCJoystickStateRelayMono relayDrone;

    public bool m_useExperiment=true;
    public string m_mustStartWith = "scratchvar:";

    public  CarDroneAsDouble m_last= new CarDroneAsDouble();

    public PlayerTankCarButtonState m_onCar;
    public PlayerDroneRCJoystickState m_onDrone;
    public PlayerTankCarRCStateChanged m_onCarChanged;
    public PlayerDroneRCJoystickStateChanged m_onDroneChanged;
    [System.Serializable]
    public class CarDroneAsDouble {
        public string m_valueAsText;
        public double m_valueAsDouble;
        public bool m_carMotorLT;
        public bool m_carMotorRT;
        public bool m_carMotorLD;
        public bool m_carMotorRD;
        public float m_droneLeftRightRotation;
        public float m_droneDownUpMotion;
        public float m_droneLeftRightMotion;
        public float m_droneBackFrontMotion;
        public bool m_carAction;
        public bool m_droneAction;
    }


    public string m_testA = "scratchvar:Test1:1000000000000000";
    public string m_testB = "scratchvar:Test1:1000000000000000";
    [ContextMenu("PushTestA")]
    public void PushTestA() { PushStringFromScratch(m_testA); }

    [ContextMenu("PushTestB")]
    public void PushTestB() { PushStringFromScratch(m_testB); }

    public void PushStringFromScratch(string textReceived)
    {
        if (!m_useExperiment)
            return;
        textReceived = textReceived.Trim().ToLower();
        if (!textReceived.StartsWith(m_mustStartWith))
            return;
        string[] tokens = textReceived.Split(":");

        if (tokens.Length == 3)
        {
            if (double.TryParse(tokens[2].Trim(), out double valueDouble))
            {

                string name = tokens[1];
                string doubleAsText = string.Format("{0:0000000000000000}",valueDouble);
                m_last.m_valueAsText = doubleAsText;
                m_last.m_valueAsDouble = valueDouble;
                //1100 0000 0000 0000
                //1 1111 99 99 99 99 000
                if (doubleAsText.Length == 16)
                {
                    m_last.m_carMotorLT = doubleAsText[1] == '1';
                    m_last.m_carMotorRT = doubleAsText[2] == '1';
                    m_last.m_carMotorLD = doubleAsText[3] == '1';
                    m_last.m_carMotorRD = doubleAsText[4] == '1';
                    V99Parse(doubleAsText, 5, 6, ref m_last.m_droneLeftRightRotation);
                    V99Parse(doubleAsText, 7, 8, ref m_last.m_droneDownUpMotion);
                    V99Parse(doubleAsText, 9, 10, ref m_last.m_droneLeftRightMotion);
                    V99Parse(doubleAsText, 11, 12, ref m_last.m_droneBackFrontMotion);
                    m_last.m_carAction = doubleAsText[13] == '1';
                    m_last.m_droneAction = doubleAsText[14] == '1';

                    m_onCar.m_buttonStateOfPlayer.m_leftForward = m_last.m_carMotorLT;
                    m_onCar.m_buttonStateOfPlayer.m_leftBackward = m_last.m_carMotorLD;
                    m_onCar.m_buttonStateOfPlayer.m_rightForward = m_last.m_carMotorRT;
                    m_onCar.m_buttonStateOfPlayer.m_rightBackward = m_last.m_carMotorRD;

                    m_onCarChanged.Invoke(m_onCar);

                    m_onDrone.m_buttonStateOfPlayer.m_rotateLeft2Right = m_last.m_droneLeftRightRotation;
                    m_onDrone.m_buttonStateOfPlayer.m_horizontalLeft2Right = m_last.m_droneLeftRightMotion;
                    m_onDrone.m_buttonStateOfPlayer.m_verticalDown2Up = m_last.m_droneDownUpMotion;
                    m_onDrone.m_buttonStateOfPlayer.m_frontalBack2Front = m_last.m_droneBackFrontMotion;

                    m_onDroneChanged.Invoke(m_onDrone);


                    m_idInScene.GetKey(m_idTarget, out bool found, out m_idTargetGameObject);
                    Debug.Log("Test   d "+m_idTarget+" "+found);
                    if (found && m_idTargetGameObject != null) {
                          
                        m_idTargetRoot = m_idTargetGameObject.GetComponentInParent<DroneGameItemRootTag>();
                        if (m_idTargetRoot != null) {

                            relayCar = m_idTargetRoot.GetComponent<PlayerTankCarButtonStateRelayMono>();
                             relayDrone = m_idTargetRoot.GetComponent<PlayerDroneRCJoystickStateRelayMono>();
                            if(relayCar)
                                relayCar.Push(m_onCar);
                            if(relayDrone)
                                relayDrone.Push(m_onDrone);

                        }

                    }
                }

            }

        }
    }
    private void V99Parse(string doubleAsText, int indexA, int indexB, ref float toAffect )
    {
        if (int.TryParse(string.Join("", doubleAsText[indexA], doubleAsText[indexB]), out int v99))
        {
            if (v99 == 0)
                toAffect = 0;
            else 
                toAffect = (((v99 - 1f) / 98f) - 0.5f) * 2f;
        }
    }

    
}
