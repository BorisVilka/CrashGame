using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Webview : MonoBehaviour
{
    [SerializeField] UniWebView webview;
    // Start is called before the first frame update
    void Start()
    {
        string url = PlayerPrefs.GetString("url");
        webview.Load(url);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
