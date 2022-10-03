using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerWhenPickup : OnTriggerReceiver
{
    public SkinItemDatabase SkinitemDB;
    public AudioClip coinSound;
    public AudioClip FlowerSound;
    
    [SerializeField] OnTriggerReceiver onTriggerReceiver;

    void Start(){
        // onTriggerReceiver.onTriggerEnter += FlowerTriggered;
        // onTriggerReceiver.onTriggerEnter += pickUpBigFlower;
        // onTriggerReceiver.onTriggerEnter += pickUpCoin;
        // onTriggerReceiver.onTriggerEnter += pickUpDiamond;
        // onTriggerReceiver.onTriggerEnter += pickUpRandomItem;
    }

    public void FlowerTriggered(GameObject item){

        AudioSource.PlayClipAtPoint(FlowerSound, item.transform.position);
        Pickup.PointCount+=Pickup.PointValue;
    }

    public void BigFlowerTriggered(GameObject item){

        AudioSource.PlayClipAtPoint(FlowerSound, item.transform.position);
        Pickup.PointValue = Pickup.PointValue * 10;
        Pickup.PointCount += Pickup.PointValue;
        Pickup.PointValue = Pickup.PointValue / 10;
    }

    public void CoinTriggered(GameObject item){

        AudioSource.PlayClipAtPoint(coinSound, item.transform.position);
        Pickup.coinCount += Pickup.CoinValue;
    }

    public void DiamondTriggered(GameObject item){
        
        AudioSource.PlayClipAtPoint(coinSound, item.transform.position);
        Pickup.DiamondCount++;
        Destroy(item);
    }

    public void RandomItemTriggered(GameObject item){
        AudioSource.PlayClipAtPoint(FlowerSound, item.transform.position);
        checkSkinItem(item);
        Destroy(item);
            
    }

    void checkSkinItem(GameObject item){
        for(int j=0;j<SkinitemDB.SkinCount;j++){
                if(item.gameObject.name==SkinitemDB.GetSkin(j).skinname){

                    SkinitemDB.GetSkin(j).amount +=1;
                }
            }
    }


}