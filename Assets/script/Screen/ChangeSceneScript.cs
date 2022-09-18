using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{

    public void ChangeSceneToCloset(){
        SceneManager.LoadScene("Closet"); 
    }

    public void ChangeSceneToMenu(){
        SceneManager.LoadScene("Menu"); 
    }

    public void ChangeSceneToTutorial(){
        SceneManager.LoadScene("Tutorial"); 
    }

    public void ChangeSceneToLevel1(){
        Time.timeScale = 1;
        SceneManager.LoadScene("Level1"); 
    }
}
