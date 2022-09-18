using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreateItemAndObjectPooling : MonoBehaviour
{
    public GameObject randomitemPrefab;
    public SkinItemDatabase SkinitemDB;
    public static List<GameObject> SkinItemList = new List<GameObject>();

   private void CreateObjectsToFillPool() {
       for(int j=0;j<SkinitemDB.SkinCount;j++){
           int amounttocreate = 5-SkinitemDB.GetSkin(j).amount;
           
           for(int i=0;i<amounttocreate;i++){
                GameObject item = Instantiate(randomitemPrefab);

                item.name = SkinitemDB.GetSkin(j).skinname;
                item.GetComponent<SpriteRenderer>().sprite = SkinitemDB.GetSkin(j).itemsprite;

                item.SetActive(false);

                SkinItemList.Add(item);
            }
       }
   }

   void Start() {
       CreateObjectsToFillPool();
   }

   private GameObject RandomItem(){
       int randomNumber = Random.Range(0,39);
       GameObject objectafterrandom = SkinItemList[randomNumber];
       SkinItemList.RemoveAt(randomNumber);

       return objectafterrandom;
   }
   
   public GameObject BorrowObjectFromPool() {
       return RandomItem();
   }

   public static void ReturnObjectToPool(GameObject objectToReturn) {
        objectToReturn.SetActive(false);

        SkinItemList.Add(objectToReturn);
   }
}
