using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class ScraperGameLogTargetUDPMono : MonoBehaviour
{
    public UdpClient udpClient = new UdpClient();
    public string m_ipTarget = "127.0.0.1";
    public int m_portTarget = 7071;
    public void PushUTF8(string message) {        
            if(udpClient==null)
                udpClient = new UdpClient();
            byte[] messageBytes = Encoding.ASCII.GetBytes(message);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse(m_ipTarget), m_portTarget);
            udpClient.Send(messageBytes, messageBytes.Length, endPoint);
    }
}
