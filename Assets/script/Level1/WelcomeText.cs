using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WelcomeText : MonoBehaviour
{
    public TMP_Text welcometext; 
    void Start()
    {
        welcometext.text = "Ready";
    }

    void Update()
    {
        if(CharacterAnimation.isGamestart == true){
            StartCoroutine(DisplayTextWithDelay(welcometext,"GO!!!",2.0f));
        }
    }
    IEnumerator DisplayTextWithDelay(TMP_Text textobj,string text,float delay){
        textobj.SetText(text);
        yield return new WaitForSeconds(delay);
        textobj.gameObject.SetActive(false);

    }
}
