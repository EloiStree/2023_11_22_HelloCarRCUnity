using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Networking;

public class PushAndLoopReceivedTextWWW : MonoBehaviour
{

    public long m_sent = 0;
    public long m_receivedPrevious = 0;
    public long m_receivedCurrent = 0;
    public bool m_found = false;
    public long m_tick;
    public double m_seconds;
    public double m_milliseconds;
    [TextArea()]
    public string m_lastTextReceived = "";

    DateTime m_sendingStarDownload;
    DateTime m_sendingStopDownload;
    DateTime m_sentDownload;
    DateTime m_startDownload;
    DateTime m_endDownload;


    public UnityEventString m_onPushString;
    [System.Serializable]
    public class UnityEventString : UnityEvent<string> { }

    public void Start()
    {
        StartCoroutine(CooroutineFetch());
    }
    IEnumerator CooroutineFetch()
    {
        m_sent = DateTime.Now.Ticks;
        m_sendingStarDownload = DateTime.Now;
        //yield return SendData(m_sent);
        m_onPushString.Invoke("" + m_sent);
        //yield return SendPostRequest(""+m_sent);
       // Debug.Log("Sent Time: " + ((m_sendingStopDownload - m_sendingStarDownload).TotalSeconds));
        m_sentDownload = DateTime.Now;
        m_sendingStopDownload = DateTime.Now;
        while (!m_found)
        {
            yield return new WaitForSeconds(0.2f);
            yield return new WaitForEndOfFrame();
            m_startDownload = DateTime.Now;
            yield return ReadWebPage();
            m_endDownload = DateTime.Now;
            //Debug.Log("Try DL Page " + (m_endDownload - m_startDownload).TotalSeconds);
        }
        m_tick = m_receivedCurrent - m_sent;
        m_seconds = (double)m_tick / TimeSpan.TicksPerSecond;
        m_milliseconds = m_seconds * 1000.0;

        Debug.Log("Try DLDDD" + (m_endDownload - m_sentDownload).TotalSeconds);
        Debug.Log("I am out bitch " + (m_milliseconds));
    }

    public string urlPush = "https://brieux.be/drone/";
    public string urlReceive = "http://brieux.be/request";


    IEnumerator SendData(long value)
    {
        //string fullUrl = url + "?time=" + value;
        string fullUrl = urlPush + value;
        UnityWebRequest www = UnityWebRequest.Get(fullUrl);
        yield return www.SendWebRequest();
        // Check for errors
        if (www.isNetworkError || www.isHttpError)
        {
            Debug.LogError("Error: " + www.error);
        }
        else
        {
            // Request was successful
            Debug.Log("Data sent successfully");
        }
    }
    IEnumerator ReadWebPage()
    {
        UnityWebRequest www = UnityWebRequest.Get(urlReceive);

        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {
            m_lastTextReceived = www.error;
        }
        else
        {
            string webpageText = www.downloadHandler.text;
            int index= webpageText.IndexOf(m_sent.ToString());
            if (index > -1) {
                m_receivedPrevious = m_receivedCurrent;
                m_receivedCurrent = DateTime.Now.Ticks;
                m_found = true;
            }
          
        }
    }
    // The URL of the web page you want to send the POST request to
    public string postUrl = "http://localhost:80/push.php";

    // The text message you want to send
    public string m_formName = "updated_text";
    IEnumerator SendPostRequest(string text )
    {
        // Create a form to hold the data you want to send
        WWWForm form = new WWWForm();
        form.AddField(m_formName, text);

        // Create a UnityWebRequest object and set the method to POST
        UnityWebRequest request = UnityWebRequest.Post(postUrl, form);

        // Set the content type to form data
        request.SetRequestHeader("Content-Type", "application/x-www-form-urlencoded");

        // Send the request and wait for a response
        yield return request.SendWebRequest();

        // Check for errors
        if (request.result == UnityWebRequest.Result.ConnectionError ||
            request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("Error: " + request.error);
        }
        else
        {
            // Request was successful, do something with the response
            Debug.Log("Response: " + request.downloadHandler.text);
        }
    }

    public string fullPathToWriteOn = "";
    public void WriteFile(string text) { 
        File.WriteAllText(fullPathToWriteOn, text);
    }
}
