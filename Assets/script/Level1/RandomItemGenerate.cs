using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

        List<int> RanNum = new List<int>();
        RanNum.Add(randomNumber);

        var findMin = RanNum.Min();
        var result1 = RanNum.Any(x => x==1);
        var result2 = RanNum.All(x => x==2);

        if(result1)
        {
            InstantiateItem(Prefab2);
        }
        else if(result2)
        {
            InstantiateItem(Prefab3);
        }
        else if(findMin>2)
        {
            InstantiateItem(Prefab1);
        }
        RanNum.Clear();
    }

    void InstantiateItem(GameObject prefab)
    {
        RandomItem = Instantiate(prefab);
        RandomItem.SetActive(true);
        StopAllCoroutines();
    }
}
