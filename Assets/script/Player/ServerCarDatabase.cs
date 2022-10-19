
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Defective.JSON;

public class ServerCarDatabase : CarDatabase
{
    [SerializeField] string url;
    public override void PrepareDatas()
    {
        StartCoroutine(DownloadCarDatabase());
    }

    IEnumerator DownloadCarDatabase()
    {
        var webRequest = UnityWebRequest.Get(url);
        yield return webRequest.SendWebRequest();

        var downloaded =  webRequest.downloadHandler.text;
        var jsonObject = new JSONObject(downloaded);
        foreach(var json in jsonObject.list)
        {
            var name = "";
            json.GetField(ref name, "name");

            var des = "";
            json.GetField(ref des, "des");

            var newCarData = new CarData();
            newCarData.name = name;
            newCarData.des = des;

            carDataList.Add(newCarData);
        }
    }
}
