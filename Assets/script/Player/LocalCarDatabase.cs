using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;
using Defective.JSON;

public class LocalCarDatabase : CarDatabase{
    [SerializeField] TextAsset jsonFile;
    public override void PrepareDatas(){
        var jsonObject = new JSONObject(jsonFile.text);
        foreach(var json in jsonObject.list){
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