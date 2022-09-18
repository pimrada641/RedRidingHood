using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInformation : MonoBehaviour
{
    public TMPro.TMP_Text coinamout;
    public TMPro.TMP_Text diamondamout;

    void Update()
    {
        coinamout.text = PlayerPrefs.GetInt("Coinamout").ToString();
        diamondamout.text = PlayerPrefs.GetInt("Diamondamout").ToString();
    }
}
