using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment_PushCarAndDroneStateByIdMono : MonoBehaviour, I_PushIDToTankRC, I_PushIDToDroneRC
{
    public FindAndResolveDoubleIdInSceneMono m_idInScene;
    public string m_lastIdSearched;
    public GameObject m_idTargetGameObject;
    public DroneGameItemRootTag m_idTargetRoot;
    public PlayerTankCarButtonStateRelayMono m_relayCar;
    public PlayerDroneRCJoystickStateRelayMono m_relayDrone;




    

    public void Push(PlayerTankCarButtonState inputValue)
    {

        m_lastIdSearched = inputValue.m_playerId;
        GetTarget(inputValue.m_playerId, out m_idTargetRoot);

        if (m_idTargetRoot != null)
        {
               m_relayCar = m_idTargetRoot.GetComponent<PlayerTankCarButtonStateRelayMono>();
            if(m_relayCar==null)
                   m_relayCar = m_idTargetRoot.GetComponentInChildren<PlayerTankCarButtonStateRelayMono>();
            if (m_relayCar)
                m_relayCar.Push(inputValue);

        }
     
    }
    public void Push(PlayerDroneRCJoystickState inputValue)
    {

        m_lastIdSearched = inputValue.m_playerId;
        GetTarget(inputValue.m_playerId, out m_idTargetRoot);

        if (m_idTargetRoot != null)
        {
            m_relayDrone = m_idTargetRoot.GetComponent<PlayerDroneRCJoystickStateRelayMono>();
            if (m_relayDrone == null)
                m_relayDrone = m_idTargetRoot.GetComponentInChildren<PlayerDroneRCJoystickStateRelayMono>();
            if (m_relayDrone)
                m_relayDrone.Push(inputValue);
        }
    }

    public void PushToCarRC(string id, bool topLeft, bool topRight, bool downleft, bool downRight)
    {
        Push(new PlayerTankCarButtonState(id, topLeft, topRight, downleft, downRight));
    }

    public void PushToDroneRC(string id, float rotationLeftRight, float downUp, float leftRight, float backFront)
    {
        Push(new PlayerDroneRCJoystickState(id, rotationLeftRight, downUp, leftRight, backFront));
    }

    private void GetTarget(string id, out DroneGameItemRootTag targetTag)
    {
        targetTag = null;
        m_idInScene.GetKey(id, out bool found, out m_idTargetGameObject);
        if (found && m_idTargetGameObject != null)
        {

            targetTag= m_idTargetGameObject.GetComponentInParent<DroneGameItemRootTag>();
            if(targetTag==null)
                targetTag = m_idTargetGameObject.GetComponent<DroneGameItemRootTag>();
        }
    }
}
