using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpRealGame : MonoBehaviour
{
    public SkinItemDatabase SkinitemDB; ////Skin Item Database////
    public static int PointCount;
    private static int coinCount;
    public static int DiamondCount;
    public int PointValue = 100;
    private int CoinValue = 10;
    public TMPro.TMP_Text coinText;
    public TMPro.TMP_Text PointText;
    public AudioClip coinSound;
    public AudioClip FlowerSound;
    void FixedUpdate(){
        PointText.text = PointCount.ToString();
        coinText.text = coinCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Flower"))
        {
            AudioSource.PlayClipAtPoint(FlowerSound, other.transform.position);
            PointCount+=PointValue;

            StartCoroutine(FontSize());
        }
        if (other.CompareTag("Bigflower"))
        {
            AudioSource.PlayClipAtPoint(FlowerSound, other.transform.position);
            PointValue=PointValue*10;
            PointCount+=PointValue;
            PointValue=PointValue/10;
            
            StartCoroutine(FontSize());

        }
        if (other.CompareTag("Coin"))
        {
            AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
            coinCount+=CoinValue;
            
            StartCoroutine(FontSize());

        }
        if (other.CompareTag("Random Item")){ ///////Random Item//////////
            AudioSource.PlayClipAtPoint(FlowerSound, other.transform.position);

            for(int j=0;j<SkinitemDB.SkinCount;j++){
                if(other.gameObject.name==SkinitemDB.GetSkin(j).skinname){

                    SkinitemDB.GetSkin(j).amount +=1;
                    
                    Destroy(other.gameObject);
                }
            }
        }
        
        if (other.CompareTag("Diamond"))
        {
            AudioSource.PlayClipAtPoint(coinSound, other.transform.position);
            DiamondCount++;
            Destroy(other.gameObject);
        }
        
        IEnumerator FontSize(){
            if(other.CompareTag("Flower")||(other.CompareTag("Bigflower"))){
                PointText.fontSize += 10;
                yield return new WaitForSeconds(0.04f);
                PointText.fontSize -= 10;
                Destroy(other.gameObject);
            }
            
            if(other.CompareTag("Coin")){
                coinText.fontSize += 10;
                yield return new WaitForSeconds(0.04f);
                coinText.fontSize -= 10;
                Destroy(other.gameObject);
            }
        }
    }
    public void IncreaseCoin(int numberOfCoin){
        coinCount = coinCount + numberOfCoin;
        coinText.text = coinCount.ToString();
    }
    
    
}
