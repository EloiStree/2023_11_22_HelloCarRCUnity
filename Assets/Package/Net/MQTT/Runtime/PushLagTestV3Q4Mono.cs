using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using UnityEngine.Events;

public class PushLagTestV3Q4Mono : MonoBehaviour
{

    public Fulldata m_info = new Fulldata();
    public Fulldata m_received = new Fulldata();

    [System.Serializable]
    public class Fulldata {
        public ulong m_id=0;
        public bool[] m_isActive=new bool[] { };
        public float[] m_isSpeed = new float[] { };
    }

    public StringEvent m_pushText;
    public ByteEvent m_pushBytes;
    [System.Serializable]
    public class StringEvent : UnityEvent<string> { }
    [System.Serializable]
    public class ByteEvent : UnityEvent<byte[]> { }

    public float m_timeBetween = 1;

    private void Start()
    {
        InvokeRepeating("PushData", 0, m_timeBetween);
    }

    void PushData()
    {
        
        GetTimeULongIdWithNow(out ulong id);
        m_info.m_id = id;
        m_pushText.Invoke(JsonUtility.ToJson(m_info));
        m_pushBytes.Invoke(SerializeToBytes(m_info));
    }
    public static void GetTimeULongIdWithNow(out ulong id)
    {
        GetTimeULongId(DateTime.Now, out id);
    }


    public static void GetTimeULongId(in DateTime time, out ulong id)
    {
        string createdDate = time.ToString("yyyy MM dd HH mm ss ffff");
        id = ulong.Parse(createdDate.Replace(" ", ""));
    }
    public ulong m_timePast;
    public void ReceivedMessage(string t)
    {

        //try
        //{
        GetTimeULongIdWithNow(out ulong id);
        m_received = JsonUtility.FromJson<Fulldata>(t);
        m_timePast = id - m_received.m_id;
        //}
        //catch (Exception) { }
    }
    public void ReceivedMessage(byte[] t)
    {

        //try
        //{
        GetTimeULongIdWithNow(out ulong id);
        m_received = DeserializeFromBytes(t);
        m_timePast = id - m_received.m_id;
        //}
        //catch (Exception) { }
    }

    static byte[] SerializeToBytes(Fulldata obj)
    {
        using (MemoryStream memoryStream = new MemoryStream())
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(memoryStream, obj);
            return memoryStream.ToArray();
        }
    }

    static Fulldata DeserializeFromBytes(byte[] byteArray)
    {
        using (MemoryStream memoryStream = new MemoryStream(byteArray))
        {
            IFormatter formatter = new BinaryFormatter();
            return (Fulldata)formatter.Deserialize(memoryStream);
        }
    }
}
