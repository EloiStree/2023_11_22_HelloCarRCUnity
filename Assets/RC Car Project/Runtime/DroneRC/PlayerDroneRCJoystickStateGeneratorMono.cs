
using UnityEngine;

public class PlayerDroneRCJoystickStateGeneratorMono : MonoBehaviour
{

    public PlayerDroneRCJoystickStateChanged m_onRelay;
    public PlayerDroneRCJoystickState m_generatedToPush;

    public void Push()
    {
        m_onRelay.Invoke(m_generatedToPush);
    }
    public void SetPlayerId(string playerId)
    {
        m_generatedToPush.m_playerId = playerId;
    }

    public void SetHorizontalLeftRight(float percent) { m_generatedToPush.m_buttonStateOfPlayer.m_horizontalLeft2Right = percent; }
    public void SetFrontalBackFront(float percent) { m_generatedToPush.m_buttonStateOfPlayer.m_frontalBack2Front = percent; }
    public void SetVerticalDownUp(float percent) { m_generatedToPush.m_buttonStateOfPlayer.m_verticalDown2Up = percent; }
    public void SetRotationLeftRight(float percent) { m_generatedToPush.m_buttonStateOfPlayer.m_rotateLeft2Right = percent; }
    public void SetHorizontalLeftRightAndPush(float percent) { SetHorizontalLeftRight(percent); Push(); }
    public void SetFrontalBackFrontAndPush(float percent) { SetFrontalBackFront(percent); Push(); }
    public void SetVerticalDownUpAndPush(float percent) { SetVerticalDownUp(percent); Push(); }
    public void SetRotationLeftRightAndPush(float percent) { SetRotationLeftRight(percent); Push(); }
}
