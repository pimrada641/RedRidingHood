using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pickup : MonoBehaviour
{
    public static int PointCount;
    private static int coinCount;
    public static int DiamondCount;
    public int PointValue = 100;
    private int CoinValue = 10;
    public TMPro.TMP_Text coinText;
    public TMPro.TMP_Text PointText;
    public AudioClip coinSound;
    public AudioClip FlowerSound;
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
        SendOther = other.gameObject;
        if (other.CompareTag("Flower"))
        {
            FlowerTriggered();
        }

        if (other.CompareTag("Bigflower"))
        {
            BigFlowerTriggered();
        }

        if (other.CompareTag("Coin"))
        {
            CoinTriggered();
        }

        if (other.CompareTag("Diamond"))
        {
            DiamondTriggered();
        }
    }

    IEnumerator FontSize()
    {
        if (SendOther.CompareTag("Flower") || (SendOther.CompareTag("Bigflower")))
        {
            FontSizeDetect(PointText);
        }

        if (SendOther.CompareTag("Coin"))
        {
            FontSizeDetect(coinText);
        }
        yield return null;
    }

    IEnumerator FontSizeDetect(TMP_Text objectText)
        {
            objectText.fontSize += 10;
            yield return new WaitForSeconds(0.04f);
            objectText.fontSize -= 10;
            Destroy(SendOther.gameObject);
        }

        void FlowerTriggered()
        {
            AudioSource.PlayClipAtPoint(FlowerSound, SendOther.transform.position);
            PointCount += PointValue;
            StartCoroutine(FontSize());
        }

        void BigFlowerTriggered()
        {
            AudioSource.PlayClipAtPoint(FlowerSound, SendOther.transform.position);
            PointValue = PointValue * 10;
            PointCount += PointValue;
            PointValue = PointValue / 10;
            StartCoroutine(FontSize());
        }

        void CoinTriggered()
        {
            AudioSource.PlayClipAtPoint(coinSound, SendOther.transform.position);
            coinCount += CoinValue;
            StartCoroutine(FontSize());
        }

        void DiamondTriggered()
        {
            AudioSource.PlayClipAtPoint(coinSound, SendOther.transform.position);
            DiamondCount++;
            Destroy(SendOther.gameObject);
        }

        public void IncreaseCoin(int numberOfCoin)
        {
            coinCount = coinCount + numberOfCoin;
            PlayerPrefs.SetInt("Coinamout", coinCount);
            coinText.text = coinCount.ToString();
        }
}