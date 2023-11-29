using System.Net;
using System.Net.Sockets;
using UnityEngine;
using UnityEngine.UI;

public class DisplayLocalIP : MonoBehaviour
{
    public Text ipAddressText;

    // Start is called before the first frame update
    void Start()
    {
        DisplayIPAddress();
    }

    void DisplayIPAddress()
    {
        string ipAddress = GetLocalIPAddress();
        ipAddressText.text = ipAddress;
    }

    string GetLocalIPAddress()
    {
        string ipAddress = "";

        try
        {
            // Get the local machine's IP addresses
            string hostName = Dns.GetHostName();
            IPHostEntry ipEntry = Dns.GetHostEntry(hostName);

            foreach (IPAddress ipAddr in ipEntry.AddressList)
            {
                // Check for IPv4 addresses
                if (ipAddr.AddressFamily == AddressFamily.InterNetwork)
                {
                    ipAddress += ipAddr.ToString()+" ";
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error getting local IP address: " + e.Message);
        }

        return ipAddress;
    }
}