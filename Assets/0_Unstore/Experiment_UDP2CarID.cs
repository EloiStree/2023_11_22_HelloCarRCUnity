using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experiment_UDP2CarID : MonoBehaviour
{


    public bool m_useExperiment = true;
    public string m_mustStartWith = "txtcmd:";

    public PlayerTankCarRCStateChanged m_onCar;
    public PlayerDroneRCJoystickStateChanged m_onDrone;
    public PlayerTankCarButtonState m_lastSentCar;
    public PlayerDroneRCJoystickState m_lastSentDrone;
    public string m_lastReceived;
    public void PushCommand(string textReceived)
    {
        if (!m_useExperiment)
            return;

        m_lastReceived = textReceived;

        textReceived = textReceived.Trim();
        string textReceivedLow = textReceived.ToLower();
        if (!textReceivedLow.StartsWith(m_mustStartWith.ToLower()))
            return;
        string[] tokens = textReceived.Split(":");

        // udpcmd:car:ID:1001
        // udpcmd:tank:ID:1001
        // udpcmd:drone:ID:1001
        // udpcmd:double:ID:1111199999999000

        if (Start(textReceivedLow, m_mustStartWith+"car:")){
            string id = tokens[2].Trim();
            string input = RemoveWhiteSpace(tokens[3]);
            if (input.Length == 4) {

                PlayerTankCarButtonState s
                    = new PlayerTankCarButtonState(id,
                    input[0] == '1',
                    input[1] == '1',
                    input[2] == '1',
                    input[3] == '1'
                    );
                m_onCar.Invoke(s);
                m_lastSentCar = s;
            }
            else {
                string[] inputTokens = RemoveWhiteSpace(input.ToLower()).Split(" ");


                PlayerTankCarButtonState d = new PlayerTankCarButtonState();
                d.m_playerId = id;
                if (inputTokens.Length >= 1)
                    d.m_buttonStateOfPlayer.m_leftForward = GetBool(inputTokens[0]);
                if (inputTokens.Length >= 2)
                    d.m_buttonStateOfPlayer.m_rightForward = GetBool(inputTokens[1]);
                if (inputTokens.Length >= 3)
                    d.m_buttonStateOfPlayer.m_leftBackward = GetBool(inputTokens[2]);
                if (inputTokens.Length >= 4)
                    d.m_buttonStateOfPlayer.m_rightBackward = GetBool(inputTokens[3]);
                m_onCar.Invoke(d);
                m_lastSentCar = d;
            }
        }
        if (Start(textReceivedLow, m_mustStartWith+"drone:"))
        {
            string id = tokens[2].Trim();
            string input = RemoveWhiteSpace( tokens[3]);
            string[] inputTokens = input.ToLower().Split(" ");


                PlayerDroneRCJoystickState d = new PlayerDroneRCJoystickState();
                d.m_playerId = id;
                d.m_buttonStateOfPlayer.m_isPowerOn = true;
                if (inputTokens.Length >= 1)
                    d.m_buttonStateOfPlayer.m_rotateLeft2Right = GetFloat(inputTokens[0]);
                if (inputTokens.Length >= 2)
                    d.m_buttonStateOfPlayer.m_verticalDown2Up = GetFloat(inputTokens[1]);
                if (inputTokens.Length >= 3)
                    d.m_buttonStateOfPlayer.m_horizontalLeft2Right = GetFloat(inputTokens[2]);
                if (inputTokens.Length >= 4)
                    d.m_buttonStateOfPlayer.m_frontalBack2Front = GetFloat(inputTokens[3]);

            m_onDrone.Invoke(d);
            m_lastSentDrone = d;
        }
}

    public string RemoveWhiteSpace(string text, int forCounter=30) {
        text = text.Trim();
        for (int i = 0; i < forCounter; i++)
        {
            text = text.Replace("  ", " ");

        }
        return text;
    }

    private float GetFloat(string givenText)
    {
        float.TryParse(givenText, out float value);
        value = Mathf.Clamp(value, -1.0f, 1.0f);
        return value;
    }
    private bool GetBool(string v)
    {
        if (v == null) return false;
        if (v == "1") return true;
        if (v.Trim() == "true") return true;
        return false;
    }

    private bool Start(string text, string start)
    {
        return text.StartsWith(start);
    }
}
