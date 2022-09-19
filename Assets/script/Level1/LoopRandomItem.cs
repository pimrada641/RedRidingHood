using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoopRandomItem : MonoBehaviour
{
    void Update()
    {
        if(CharacterAnimation.isGamestart == true){
            transform.position += new Vector3(-4 * Time.deltaTime,0);

            if(this.gameObject.transform.position.x <= -30){
                CreateItemAndObjectPooling.ReturnObjectToPool(this.gameObject);
            }
        }

    }
}
