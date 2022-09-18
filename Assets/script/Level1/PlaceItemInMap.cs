using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaceItemInMap : MonoBehaviour
{
    public CreateItemAndObjectPooling createscript;
    IEnumerator WaitBeforePlace(){
        yield return new WaitForSeconds(60); 
        createscript.BorrowObjectFromPool().SetActive(true);
        StopAllCoroutines();
    }

    void Update()
    {
        StartCoroutine(WaitBeforePlace());
    }
}
