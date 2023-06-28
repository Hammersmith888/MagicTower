using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class GetVersionGP : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        using (UnityWebRequest webRequest = UnityWebRequest.Get("https://play.google.com/store/apps/details?id=com.akpublish.magicsiege&hl=en"))
        {
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            if (webRequest.isNetworkError)
            {
               // Debug.Log(pages[page] + ": Error: " + webRequest.error);
            }
            else
            {
                //console.log($('<div/>').html(data).contents().find('div[itemprop="softwareVersion"]').text().trim());
                var str = webRequest.downloadHandler.text;
                Debug.Log($"{str}");
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
