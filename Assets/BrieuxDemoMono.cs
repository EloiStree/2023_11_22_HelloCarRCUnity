using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class BrieuxDemoMono : MonoBehaviour
{
    // The URL of the web page you want to send the POST request to
    public  string postUrl = "https://localhost:80/push.php";

    // The text message you want to send
    public string messageText = "Hello, Webpage!";
    public string m_formName = "updated_text";
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(SendPostRequest());
    }

}
