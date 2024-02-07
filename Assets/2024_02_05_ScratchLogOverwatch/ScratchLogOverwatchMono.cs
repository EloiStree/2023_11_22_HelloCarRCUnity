using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class ScratchLogOverwatchMono : MonoBehaviour
{

    // TO DO: Check very n seconds for new input
    // if one detected go it play mode 
    // But if all are true, go in 50 every 0.25 seconds
    // If 50 are all new  got for 300 every 0.1 seconds
    // Use a quite mode > active mode > players are playing mode.
    // I means do something to not check to much on the server. Only when a game is in process and the player active.
    public string m_projectId = "960534356";
    public string m_limite = "300";
    public float m_waitTimeBetweenDownload = 3;
    public string m_logUrl = "https://clouddata.scratch.mit.edu/logs?projectid={0}&limit={1}&offset=0";

    [TextArea(0, 5)]
    public string m_currentJson;
    [TextArea(0, 5)]
    public string m_previousJson;


    public JsonScratchJsonCloudVarList jsonDataArrayCurrent;
    public JsonScratchJsonCloudVarList jsonDataArrayPrevious;
    public List<JsonScratchJsonCloudVarItem> newValues;

    private bool m_firstDl=true;
    public void Start()
    {
        StartCoroutine(CheckLog());

        Debug.Log(JsonUtility.ToJson(new JsonScratchJsonCloudVarList() { items = new JsonScratchJsonCloudVarItem[] { new JsonScratchJsonCloudVarItem() } }));
    }

    private IEnumerator CheckLog()
    {
        while (true)
        {
            yield return new WaitForEndOfFrame();
            if (m_waitTimeBetweenDownload < 0.5)
                m_waitTimeBetweenDownload = 0.5f;
            yield return new WaitForSeconds(m_waitTimeBetweenDownload);
            string url = string.Format(m_logUrl, m_projectId, m_limite);
            using (UnityWebRequest webRequest = UnityWebRequest.Get(url))
            {
                // Send the request and wait for a response
                yield return webRequest.SendWebRequest();

                // Check for errors
                if (webRequest.isNetworkError || webRequest.isHttpError)
                {
                    m_previousJson = m_currentJson;
                    m_currentJson = "";
                    jsonDataArrayPrevious = jsonDataArrayCurrent;
                    jsonDataArrayCurrent = new JsonScratchJsonCloudVarList();
                }
                else
                {
                    string webpageContent = webRequest.downloadHandler.text;
                    m_previousJson = m_currentJson;
                    m_currentJson = webpageContent;

                    jsonDataArrayPrevious = jsonDataArrayCurrent;
                    jsonDataArrayCurrent = JsonUtility.FromJson<JsonScratchJsonCloudVarList>("{\"items\":" + m_currentJson + "}");

                    if (m_firstDl) { m_firstDl = false; }
                    else { 
                        newValues = 
                            jsonDataArrayCurrent.items.Except(
                                jsonDataArrayPrevious.items, 
                                new JsonScratchJsonCloudVarItemComparer()).ToList();
                    }


                }
            }

        }// Custom comparer to compare JsonScratchJsonCloudVarItem objects

    }
}
    public class JsonScratchJsonCloudVarItemComparer : IEqualityComparer<JsonScratchJsonCloudVarItem>
    {
        public bool Equals(JsonScratchJsonCloudVarItem x, JsonScratchJsonCloudVarItem y)
        {
            // Compare based on the unique identifier generated by GetUnique
            return x.GetUnique() == y.GetUnique();
        }

        public int GetHashCode(JsonScratchJsonCloudVarItem obj)
        {
            // Implement GetHashCode if needed
            return obj.GetUnique().GetHashCode();
        }
    }
    [Serializable]
public class JsonScratchJsonCloudVarList
{
    public JsonScratchJsonCloudVarItem[] items= new JsonScratchJsonCloudVarItem[0];
}

[Serializable]
public class JsonScratchJsonCloudVarItem
{
    public string user;
    public string verb;
    public string name;
    public int value;
    public long timestamp;
    public string GetUnique() { return string.Format("{0}{1}{2}", timestamp, user, name);}
}