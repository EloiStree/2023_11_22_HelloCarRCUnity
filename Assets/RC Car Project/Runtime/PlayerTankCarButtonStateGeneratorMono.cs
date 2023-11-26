
using UnityEngine;

public class PlayerTankCarButtonStateGeneratorMono : MonoBehaviour
{

    public PlayerTankCarRCStateChanged m_onRelay;
    public PlayerTankCarButtonState m_generatedToPush;

    public void Push()
    {
        m_onRelay.Invoke(m_generatedToPush);
    }
    public void SetPlayerId(string playerId)
    {
        m_generatedToPush.m_playerId = playerId;
    }
    public void SetLeftForward(bool isStateOn) { m_generatedToPush.m_buttonStateOfPlayer.m_leftForward = isStateOn; }
    public void SetLeftBackward(bool isStateOn) { m_generatedToPush.m_buttonStateOfPlayer.m_leftBackward = isStateOn; }
    public void SetRightForward(bool isStateOn) { m_generatedToPush.m_buttonStateOfPlayer.m_rightForward = isStateOn; }
    public void SetRightBackward(bool isStateOn) { m_generatedToPush.m_buttonStateOfPlayer.m_rightBackward = isStateOn; }
    public void SetLeftForwardAndPush(bool isStateOn) { SetLeftForward(isStateOn); Push(); }
    public void SetLeftBackwardAndPush(bool isStateOn) { SetLeftBackward(isStateOn); Push(); }
    public void SetRightForwardAndPush(bool isStateOn) { SetRightForward(isStateOn); Push(); }
    public void SetRightBackwardAndPush(bool isStateOn) { SetRightBackward(isStateOn); Push(); }
}
