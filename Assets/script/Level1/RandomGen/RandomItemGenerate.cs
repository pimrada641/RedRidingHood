using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[RequireComponent(typeof(RandomGenerator))]
public class RandomItemGenerate : MonoBehaviour
{
    // public GameObject Prefab1,Prefab2,Prefab3;
    GameObject RandomItem;
    public RandomGenerator generator;

    private void Awake() {
        generator = GetComponent<RandomGenerator>();
    }
    
    private void Start() {
        generator.SortPossibility();
    }

    void Update()
    {
        StartCoroutine(randomItemgen());
    }

    IEnumerator randomItemgen(){
        yield return new WaitForSeconds(4);
        var newlyGeneratedItem = generator.Execute();
        if (newlyGeneratedItem != null) {
            InstantiateItem(newlyGeneratedItem.Prefab);
        }
    }

    void InstantiateItem(GameObject prefab)
    {
        RandomItem = Instantiate(prefab);
        RandomItem.SetActive(true);
        StopAllCoroutines();
    }
}
