using System;
using UnityEngine;
using UnityEngine.Events;

public class ScrapeGameLogBroadcasterMono : MonoBehaviour
{
    public string m_lastBroadcast;
    public LineBroadcastEvent m_onBroadcast;

    [System.Serializable]
    public class LineBroadcastEvent : UnityEvent<string> { }

    public bool m_useLineReturn;
    public void BroadcastLine(string line) {
        m_lastBroadcast = line;
        if (m_useLineReturn)
            m_onBroadcast.Invoke(line + "\n");
        else
            m_onBroadcast.Invoke(line );
    }

    public void Push_GameScore(int setBlue, int setRed, int pointBlue, int pointRed)
    {
        // Match State  
        // G:SAAA: SetBlue SetRed  PointBlue PointRed
        BroadcastLine($"G:SAAA:{setBlue} {setRed} {pointBlue} {pointRed}");
    }


    public void Push_TimeTick() {
        BroadcastLine("Time:"+DateTime.Now.Ticks);
    }

    public void Push_GroupOfIds(string id, params string[] ids)
    {
        BroadcastLine(id + ":SIDS:" + string.Join(":", ids));
    }
    
    public void Push_ItemPositionRotation(string id, Transform root, Transform position, bool useEuler)
    {
        GetWorldToLocal_DirectionalPoint(position.position, position.rotation, root, out Vector3 local, out Quaternion locaRot);
        Push_ItemPositionRotation(id, position.position, position.rotation,  useEuler);
    }

   
    public void Push_ItemPositionRotation(string id, Vector3 localPosition, Quaternion localRotation, bool useEuler)
    {
        if (useEuler)
        {
            Vector3 e = localRotation.eulerAngles;
            BroadcastLine(id + ":t:" + string.Format("{0:0.000} {1:0.000} {2:0.000} {3:0.000} {4:0.000} {5:0.000} ",
                localPosition.x, localPosition.y, localPosition.z,
                e.x, e.y, e.z));
        }
        else {
            //nPJfL0:T:Vx Vy Vz Qx Qy Qz Qw
            BroadcastLine(id + ":T:" + string.Format("{0:0.000} {1:0.000} {2:0.000} {3:0.000} {4:0.000} {5:0.000} {6:0.000} ",
                localPosition.x, localPosition.y, localPosition.z,
                localRotation.x, localRotation.y, localRotation.z, localRotation.w));
        }
    }

    
    public void Push_ItemTags(string id, params string [] tags)
    {
        BroadcastLine(id + ":STAG:" + string.Join(" ",tags));
    }


    /// <summary>
    /// Represent the GUID of the 3D model to use for the car store in the project of asset bundle in Munity DB
    /// </summary>
    /// <param name="id"></param>
    /// <param name="modelGuid3D"></param>
    public void Push_ModelToDisplay(string id, string modelGuid3D)
    {
        BroadcastLine(id + ":S3DM:" + modelGuid3D);
    }

    /// <summary>
    /// Represent the GUID of the lua code used as logic of the element from the Munity LUA
    /// </summary>
    /// <param name="id"></param>
    /// <param name="modelGuid3D"></param>
    public void Push_LuaUsedOnTheElement(string id, string luaGuid)
    {
        BroadcastLine(id + ":SLUA:" + luaGuid);
    }


    public void Push_BasicShapeCar(string id, float widthX, float heightY, float depthZ)
    {
        BroadcastLine(id + ":SAAB: C " + string.Join(" ", widthX, heightY, depthZ));
    }

    public void Push_BasicShapeDrone(string id, float radius)
    {
        // Basic shape
        // {0} (D) drone   (C) Car
        //nPJfL0: SAAB: C Horizontal Heihgt Depth
        //nPJfL0: SAAB: D Radius
        BroadcastLine(id + ":SAAB: D " + radius);
    }


    public static void GetWorldToLocal_DirectionalPoint(in Vector3 worldPosition, in Quaternion worldRotation, in Transform rootReference, out Vector3 localPosition, out Quaternion localRotation)
    {
        Vector3 p = rootReference.position;
        Quaternion r = rootReference.rotation;
        GetWorldToLocal_DirectionalPoint(in worldPosition, in worldRotation, in p, in r, out localPosition, out localRotation);
    }
    public static void GetWorldToLocal_DirectionalPoint(in Vector3 worldPosition, in Quaternion worldRotation, in Vector3 positionReference, in Quaternion rotationReference, out Vector3 localPosition, out Quaternion localRotation)
    {
        localRotation = Quaternion.Inverse(rotationReference) * worldRotation;
        localPosition = Quaternion.Inverse(rotationReference) * (worldPosition - positionReference);
    }
    public void Push_ComplexShapeDrone(string id,
        Vector3 m_bladeOffsetFrontLeft,
        Vector3 m_bladeOffsetFrontRight,
        Vector3 m_bladeOffsetBackLeft,
        Vector3 m_bladeOffsetBackRight,
        float m_radiusOfBlade,
        float m_heightOfBlade,
        Vector3 m_boxColliderOffset,
        float m_heightOfBoxCollider,
        float m_widthOfBoxCollider,
        float m_depthOfBoxCollider)
    {

        string r = $"{id}:SBBC: D ";
        r += $"{GetV3(ref m_bladeOffsetFrontLeft)}|";
        r += $"{GetV3(ref m_bladeOffsetFrontRight)}|";
        r += $"{GetV3(ref m_bladeOffsetBackLeft)}|";
        r += $"{GetV3(ref m_bladeOffsetBackRight)}|";
        r += $"{GetFloatTuncated(ref m_radiusOfBlade)}|";
        r += $"{GetFloatTuncated(ref m_heightOfBlade)}|";
        r += $"{GetV3(ref m_boxColliderOffset)}|";
        r += $"{GetFloatTuncated(ref m_heightOfBoxCollider)}|";
        r += $"{GetFloatTuncated(ref m_widthOfBoxCollider)}|";
        r += $"{GetFloatTuncated(ref m_depthOfBoxCollider)}|";
        BroadcastLine(r);
    }
    public void Push_ComplexShapeCar(string id,
        Vector3 wheelOffsetFrontLeft, 
        Vector3 wheelOffsetFrontRight,
        Vector3 wheelOffsetBackLeft,
        Vector3 wheelOffsetBackRight,
        float   radiusOfWheels,
        float   heightOfWheels, 
        Vector3 boxCarColliderOffset, 
        float   heightOfCarCollider, 
        float   widthOfCarCollider, 
        float   depthOfCarCollider,
        Vector3 boxCarBodyColliderOffset, 
        float   heightOfCarBodyCollider, 
        float   widthOfCarBodyCollider,
        float   depthOfCarBodyCollider)
    {
        string r = $"{id}:SBBC: C ";
        r += $"{GetV3(ref wheelOffsetFrontLeft)}|";
        r += $"{GetV3(ref wheelOffsetFrontRight)}|";
        r += $"{GetV3(ref wheelOffsetBackLeft)}|";
        r += $"{GetV3(ref wheelOffsetBackRight)}|";
        r += $"{GetV3(ref wheelOffsetBackRight)}|";
        r += $"{GetFloatTuncated(ref heightOfWheels)}|";
        r += $"{GetV3(ref boxCarColliderOffset)}|";
        r += $"{GetFloatTuncated(ref heightOfCarCollider)}|";
        r += $"{GetFloatTuncated(ref widthOfCarCollider)}|";
        r += $"{GetFloatTuncated(ref depthOfCarCollider)}|";
        r += $"{GetV3(ref boxCarBodyColliderOffset)}|";
        r += $"{GetFloatTuncated(ref heightOfCarBodyCollider)}|";
        r += $"{GetFloatTuncated(ref widthOfCarBodyCollider)}|";
        r += $"{GetFloatTuncated(ref depthOfCarBodyCollider)}|";
        BroadcastLine(r);
    }

    public string GetV3(ref Vector3 v)
    {
        return string.Format("{0:0.0000} {1:0.0000} {2:0.0000}", v.x, v.y, v.z);
    }
    public string GetQ4(ref Quaternion v)
    {
        return string.Format("{0:0.0000} {1:0.0000} {2:0.0000} {3:0.0000}", v.x, v.y, v.z, v.w);
    }
    public string GetFloatTuncated(ref float v)
    {
        return string.Format("{0:0.0000}", v);
    }
}
