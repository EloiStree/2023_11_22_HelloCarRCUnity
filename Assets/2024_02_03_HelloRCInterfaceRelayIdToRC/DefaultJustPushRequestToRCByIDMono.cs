using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultJustPushRequestToRCByIDMono : JustPushRequestToRCByIDMono
{

    public List<I_HasDroneIDAsString> m_hasDroneIdAsString = new List<I_HasDroneIDAsString>();

    public override void PushToCarRC(string id, bool topLeft, bool topRight, bool downleft, bool downRight)
    {
        throw new System.NotImplementedException();
    }


    public override void PushToDroneRC(string id, float rotationLeftRight, float downUp, float leftRight, float backFront)
    {
        throw new System.NotImplementedException();
    }


    [System.Serializable]
    public struct DroneRCStateTimedId
    {
        public string carId;
        public long dateName;
        public TankRCState state;
    }
    [System.Serializable]
    public struct TankRCStateTimedId
    {
        public string carId;
        public long dateName;
        public DroneRCState state;
    }

    [System.Serializable]
    public struct DroneRCState
    {
        public float rotationLeftRight;
        public float moveDownUp;
        public float moveLeftRight;
        public float moveBackFront;
    }
    [System.Serializable]
    public struct TankRCState
    {
        public float motorTopLeft;
        public float motorTopRight;
        public float motorDownLeft;
        public float motorDownRight;
    }

}
