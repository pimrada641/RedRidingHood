using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomItemGenerate : MonoBehaviour
{
    public GameObject Prefab1,Prefab2,Prefab3;
    GameObject RandomItem;

    void Update()
    {
        StartCoroutine(randomItemgen());
    }

    IEnumerator randomItemgen(){
        yield return new WaitForSeconds(4);
        int randomNumber = Random.Range(1,20);
        if(randomNumber == 1){
            Debug.Log("Gen1");
            RandomItem = Instantiate(Prefab2);
            RandomItem.SetActive(true);
            
            StopAllCoroutines();
        }
        else if(randomNumber == 2){
            Debug.Log("Gen2");
            RandomItem = Instantiate(Prefab3);
            RandomItem.SetActive(true);
            
            StopAllCoroutines();
        }
        else{
            Debug.Log("Gen3");
            RandomItem = Instantiate(Prefab1);
            RandomItem.SetActive(true);
            
            StopAllCoroutines();
        }
    }
}
