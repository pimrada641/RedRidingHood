using System;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public abstract class CarDatabase : MonoBehaviour {
    [SerializeField] protected List<CarData> carDataList = new List<CarData>();
    protected CarData defaultData;
    private void Awake(){
        PrepareDatas();
    }

    public abstract void PrepareDatas();
    public CarData GetDefaultData(){
        return defaultData;
    }
    public CarData GetCarDataByName(string name){
        foreach(var carData in carDataList){
            if(name.Contains(carData.name)){
                return carData;
            }
        }

        return null;
    }
}