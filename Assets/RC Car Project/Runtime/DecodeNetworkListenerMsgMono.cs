using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Events;

public class DecodeNetworkListenerMsgMono : MonoBehaviour
{

    //ABCDEF|J1|LT1
    //|J2|RT2
    public PlayerTankCarRCStateChanged m_onEventReceived;
    public PlayerCarRCNetworkState[] m_playersInGame = new PlayerCarRCNetworkState[] {
        new PlayerCarRCNetworkState("J1"),
        new PlayerCarRCNetworkState("J2"),
        new PlayerCarRCNetworkState("J3"),
        new PlayerCarRCNetworkState("J4"),
        new PlayerCarRCNetworkState("J5"),
        new PlayerCarRCNetworkState("J6"),
        new PlayerCarRCNetworkState("J7"),
        new PlayerCarRCNetworkState("J8"),
        new PlayerCarRCNetworkState("J9"),
        new PlayerCarRCNetworkState("J10"),
        new PlayerCarRCNetworkState("J11"),
        new PlayerCarRCNetworkState("J12")
    };

    [System.Serializable]
    public class PlayerCarRCNetworkState
    { public static string m_passwordCharacters = "ABCDEFGHJKMNPQRSTUVWXYZAbcdefghjkmnpqrstuvwxyz123456789";
        public string m_playerPassword;
        public string m_playerNetworkId;
        public PlayerTankCarButtonState m_playerButtonState;

        public PlayerCarRCNetworkState(string playerId)
        {
            m_playerNetworkId = playerId;
            m_playerButtonState = new PlayerTankCarButtonState();
            m_playerButtonState.m_playerId = playerId;
        }
        public void GenerateNewPassword() {
            for (int i = 0; i < 8; i++)
            {
                m_playerPassword += m_passwordCharacters[UnityEngine.Random.Range(0, m_passwordCharacters.Length)];
            }
        }
    }
    [ContextMenu("Regenerate Passwords")]
    public void RegeneratePassword() {
        foreach (var item in m_playersInGame)
        {
            item.GenerateNewPassword();
        }
    }

    public void TryToDecodeMessageAsCommand(string textReceived) {
       string [] tokens = textReceived.Split(new char[] { '|' , '_' });
        if (tokens.Length == 3)
        {
            string password = tokens[0].Trim();
            string userId = tokens[1].Trim().ToLower();
            string command = tokens[2].Trim().ToUpper();
            
            PlayerCarRCNetworkState [] players= m_playersInGame.Where(k => k.m_playerPassword == password && k.m_playerNetworkId.ToLower() == userId).ToArray();
            if (players.Length >0) {
                if (command.Length == 3)
                {
                    bool isLeft = false;
                    bool isForward = false;
                    bool isTrue = false;
                    foreach (char c in command)
                    {
                        if (c == 'L') isLeft = true;
                        if (c == 'F') isForward = true;
                        if (c == '1') isTrue = true;
                        if (c == 'T') isTrue = true;
                    }
                    if (isLeft && isForward)
                    {
                        players[0].m_playerButtonState.m_buttonStateOfPlayer.m_leftForward = isTrue;
                    }
                    if (isLeft && !isForward)
                    {
                        players[0].m_playerButtonState.m_buttonStateOfPlayer.m_leftBackward = isTrue;
                    }
                    if (!isLeft && isForward)
                    {
                        players[0].m_playerButtonState.m_buttonStateOfPlayer.m_rightForward = isTrue;
                    }
                    if (!isLeft && !isForward)
                    {
                        players[0].m_playerButtonState.m_buttonStateOfPlayer.m_rightBackward = isTrue;
                    }
                    m_onEventReceived.Invoke(players[0].m_playerButtonState);
                }
                if (command.Length == 4)
                {
                    
                   
                        players[0].m_playerButtonState.m_buttonStateOfPlayer.m_leftForward = command[0]== '1';
                        players[0].m_playerButtonState.m_buttonStateOfPlayer.m_rightForward = command[1]== '1';
                        players[0].m_playerButtonState.m_buttonStateOfPlayer.m_leftBackward = command[2]== '1';
                        players[0].m_playerButtonState.m_buttonStateOfPlayer.m_rightBackward = command[3]== '1';


                    m_onEventReceived.Invoke(players[0].m_playerButtonState);
                }
            }
        }


    }
}
