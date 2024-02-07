using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class JustPushRequestToRCByIDMono : MonoBehaviour, I_PushIDToTankRC, I_PushIDToDroneRC
{
    public abstract void PushToCarRC(string id, bool topLeft, bool topRight, bool downleft, bool downRight);
    public abstract void PushToDroneRC(string id, float rotationLeftRight, float downUp, float leftRight, float backFront);
}



/// <summary>
/// Player should not try to guess what is what. Just say "This id with those value"
/// </summary>
public interface I_PushIDToTankRC
{

    public void PushToCarRC(string id, bool topLeft, bool topRight, bool downleft, bool downRight);
}


/// <summary>
/// Player should not try to guess what is what. Just say "This id with those value"
/// </summary>
public interface I_PushIDToDroneRC
{
    public void PushToDroneRC(string id, float rotationLeftRight, float downUp, float leftRight, float backFront);
}

public interface I_HasDroneIDAsString { string GetDroneIDAsString(); }

