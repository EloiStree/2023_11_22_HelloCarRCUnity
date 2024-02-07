using System.Collections;
using UnityEngine;

public class WebPageDownloader : MonoBehaviour
{
    private string url = "https://example.com"; // Replace with the URL of the webpage you want to download
    private WaitForSeconds downloadInterval = new WaitForSeconds(0.1f);

    private void Start()
    {
        StartCoroutine(DownloadWebPageRepeatedly());
    }

    private IEnumerator DownloadWebPageRepeatedly()
    {
        while (true)
        {
            yield return StartCoroutine(DownloadWebPage());
            yield return downloadInterval;
        }
    }

    private IEnumerator DownloadWebPage()
    {
        using (WWW www = new WWW(url))
        {
            yield return www;

            if (www.error != null)
            {
                Debug.LogError("Error downloading webpage: " + www.error);
            }
            else
            {
                // Process the downloaded data here
                Debug.Log("Webpage content: " + www.text);
            }
        }
    }
}