using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FadeScript : MonoBehaviour
{
    public Animator anim;
    public GameObject Fade;
    public GameObject Black;
    // Start is called before the first frame update
    void Start()
    {
        Black.SetActive(false);
    }

    void Update()
    {
        if(DialogScript.fade == true){
            Black.SetActive(true);
            StartCoroutine(FinishFade());
        }
        
    }

    IEnumerator FinishFade(){
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene("Tutorial");
        
    }
}
