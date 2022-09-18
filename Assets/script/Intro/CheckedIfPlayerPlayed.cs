using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CheckedIfPlayerPlayed : MonoBehaviour
{
    void Start()
    {
        if(PlayerPrefs.GetInt("PlayedTutorial") == 1){
            SceneManager.LoadScene("Menu");
        }
    }
}
