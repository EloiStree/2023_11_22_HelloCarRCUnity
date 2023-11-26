using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayersTankRCButtonStateRelayMono : MonoBehaviour
{


    public PlayerRelay[] m_playerRelay = new PlayerRelay[] {
     new PlayerRelay("J1"),
     new PlayerRelay("J2"),
     new PlayerRelay("J3"),
     new PlayerRelay("J4"),
     new PlayerRelay("J5"),
     new PlayerRelay("J6"),
     new PlayerRelay("J7"),
     new PlayerRelay("J8"),
     new PlayerRelay("J9"),
     new PlayerRelay("J10"),
     new PlayerRelay("J11"),
     new PlayerRelay("J12"),
     new PlayerRelay("J13")
    };
    [System.Serializable]
    public class PlayerRelay {
        public string m_userId;
        public PlayerTankCarButtonStateRelayMono m_relay;
        public PlayerRelay(string userId)
        {
            m_userId = userId;
        }
    }

    public void TryToRelay(PlayerTankCarButtonState newButtonState) {

        PlayerRelay[] player =
        m_playerRelay.Where(k => k.m_userId.ToLower().Trim() == newButtonState.m_playerId.ToLower().Trim()).ToArray();
        foreach (var item in player)
        {
            item.m_relay.Push(newButtonState);
        }

    }
}
