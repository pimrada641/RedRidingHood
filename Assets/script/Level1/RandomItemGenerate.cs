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
        if(randomNumber == 1)
        {
            InstantiateItem(Prefab2);
        }
        else if(randomNumber == 2)
        {
            InstantiateItem(Prefab3);
        }
        else
        {
            Debug.Log("Gen3");
            InstantiateItem(Prefab1);
        }
    }

    void InstantiateItem(GameObject prefab)
    {
        RandomItem = Instantiate(prefab);
        RandomItem.SetActive(true);
        StopAllCoroutines();
    }
}
