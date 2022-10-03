using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public static int PointCount;
    public static int coinCount;
    public static int DiamondCount;
    public static int PointValue = 100;
    public static  int CoinValue = 10;
    public TMPro.TMP_Text coinText;
    public TMPro.TMP_Text PointText;
    public GameObject SendOther;

    void FixedUpdate()
    {
        PlayerPrefs.SetInt("Coinamount", coinCount);
        PlayerPrefs.SetInt("Diamondamount", DiamondCount);
        PointText.text = PointCount.ToString();
        coinText.text = coinCount.ToString();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // var tryGetReceiver = other.GetComponent<OnTriggerReceiver>();
        
        SendOther = other.gameObject;

        if (other.CompareTag("Flower"))
        {
            this.gameObject.GetComponent<TriggerWhenPickup>().FlowerTriggered(SendOther);
            StartCoroutine(FontSize());
        }

        if (other.CompareTag("Bigflower"))
        {
            this.gameObject.GetComponent<TriggerWhenPickup>().BigFlowerTriggered(SendOther);
            StartCoroutine(FontSize());
        }

        if (other.CompareTag("Coin"))
        {
            this.gameObject.GetComponent<TriggerWhenPickup>().CoinTriggered(SendOther);
            StartCoroutine(FontSize());
        }

        if (other.CompareTag("Diamond"))
        {
            this.gameObject.GetComponent<TriggerWhenPickup>().DiamondTriggered(SendOther); 
            StartCoroutine(FontSize());
        }
    }

    IEnumerator FontSize()
    {
        if (SendOther.CompareTag("Flower") || (SendOther.CompareTag("Bigflower")))
        {
            StartCoroutine(FontSizeDetect(PointText));
        }

        if (SendOther.CompareTag("Coin"))
        {
            StartCoroutine(FontSizeDetect(coinText));
        }
        yield return null;
    }

    IEnumerator FontSizeDetect(TMP_Text objectText)
    {
        objectText.fontSize += 10;
        yield return new WaitForSeconds(0.04f);
        objectText.fontSize -= 10;
        DestroyItem();
    }

    public void DestroyItem(){
        Destroy(SendOther);
    }
}