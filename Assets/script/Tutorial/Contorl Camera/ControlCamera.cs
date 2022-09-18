using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;
using UnityEngine.Audio;

public class ControlCamera : MonoBehaviour
{
    public GameObject playerCamobj, finishCamobj;
    public GameObject mainCamera, character;
    public TMP_Text welcometext;
    public AudioMixerSnapshot Ingame;
    private CinemachineBrain CinemachineBrain;
    bool isGameStarted = false;
    // Start is called before the first frame update
    void Start()
    {
        CinemachineBrain = mainCamera.GetComponent<CinemachineBrain>();
        welcometext.SetText("Ready");
        character.GetComponent<ChraracterScript>().enabled = false; //ให้ตัวละครขยับไม่ได้
        finishCamobj.SetActive(true);
        playerCamobj.SetActive(false);
        StartCoroutine(FinishToPlayerCam());
        
    }

    IEnumerator FinishToPlayerCam(){
        yield return new WaitForSeconds(2);
        finishCamobj.SetActive(false);
        playerCamobj.SetActive(true);
    }

    void Update(){
        if(!CinemachineBrain.IsBlending){
            ICinemachineCamera finishcam = finishCamobj.GetComponent<ICinemachineCamera>();
            bool finishcamlive = CinemachineCore.Instance.IsLive(finishcam);
            if(!finishcamlive && !isGameStarted){
                character.GetComponent<ChraracterScript>().enabled = true;
                StartCoroutine(DisplayTextWithDelay(welcometext,"GO",2.0f));
                Ingame.TransitionTo(0.1f);
            }
        }
    }

    IEnumerator DisplayTextWithDelay(TMP_Text textobj,string text,float delay){
        textobj.SetText(text);
        yield return new WaitForSeconds(delay);
        textobj.gameObject.SetActive(false);

    }
}
