using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using UnityEngine.Audio;

public class Tutorial : MonoBehaviour
{
    public GameObject tutorialtext;

    public GameObject TutorialFinishText,TutorialPic1, TutorialPic2, TutorialPic3,TutorialPic4;

    public GameObject FlowerCam,PlayerCam;

    public GameObject FlowerTutotial2, EnemyTutorial3, ObstacleTutorial4;

    public GameObject StoryCharacter;

    public static bool TutorialComplete,PlaySoundComplete; 

    private bool Flowertutorial,Jumptutorial,Attacktutorial,ObstacleTutorial;

    public GameObject JumpButton,AttackButton,Coin,Heart,Flower;

    public AudioSource CompleteSound;

    private PlayerControls PlayerControls;

    private int index=0;
    
    private void Awake(){
        PlayerControls = new PlayerControls();
        CompleteSound = CompleteSound.GetComponent<AudioSource>();
        
    }
    private void OnEnable(){
        PlayerControls.Enable();
    }
    private void OnDisable(){
        PlayerControls.Disable();
    }

    void Update()
    {
        if(TutorialComplete == true){ 
            TutorialNowComplete(); 
        }

        float AcceptInput = PlayerControls.PlayerControl.Accept.ReadValue<float>();

        if(AcceptInput>0){
            if(FlowerCam.activeSelf && Time.timeScale == 0f){
                Continuegame();
            }
        }

        CheckTutorialAndGenItem();
        
    }

    void SetTutorialPicToFalse(){
        TutorialPic1.SetActive(false);
        TutorialPic2.SetActive(false);
        TutorialPic3.SetActive(false);
        TutorialPic4.SetActive(false);
    }

    void SetTuTorialTextToFalse(){
        tutorialtext.SetActive(false);
        TutorialFinishText.SetActive(false);
    }

    void SwapToPlayerCam(){
        PlayerCam.SetActive(true);
        FlowerCam.SetActive(false);
    }

    void SwapToFlowerCam(){
        PlayerCam.SetActive(false);
        FlowerCam.SetActive(true);
    }

    void SetButtonToFalse(){
        JumpButton.SetActive(false);
        AttackButton.SetActive(false);
    }

    void TutorialNowComplete(){
        CompleteSound.Play();
        TutorialComplete = false;
        PlaySoundComplete = true;
    }

    void Continuegame(){
        SwapToPlayerCam();
        SetTutorialPicToFalse();
        SetTuTorialTextToFalse();

        StopAllCoroutines();

        Time.timeScale = 1f;

        StartCoroutine(CooldownButtonShowup());
    }

    IEnumerator CooldownButtonShowup(){
        if(Jumptutorial == true && Attacktutorial == false){
            yield return new WaitForSeconds(1.5f);
            JumpButton.SetActive(true);
        }

        if(Attacktutorial == true){
            yield return new WaitForSeconds(1.5f);
            JumpButton.SetActive(true);
            AttackButton.SetActive(true);
        }
    }

    void CheckTutorialAndGenItem(){
        if (ChraracterScript.gamestarted==true){
            StoryCharacter.SetActive(false);

            if(Flowertutorial == false && TutorialComplete == false){
                StartCoroutine(StartEachTutorial());
            }

            if(Jumptutorial == false && Flowertutorial == true && PlaySoundComplete == true){
                FlowerTutotial2.SetActive(true);
                StartCoroutine(StartEachTutorial());
            }

            if(Attacktutorial == false && Jumptutorial == true && PlaySoundComplete == true){
                EnemyTutorial3.SetActive(true);
                StartCoroutine(StartEachTutorial());
            }

            if(ObstacleTutorial == false && Attacktutorial == true && PlaySoundComplete == true){
                ObstacleTutorial4.SetActive(true);
                StartCoroutine(StartEachTutorial());
            }

            if(ObstacleTutorial == true && PlaySoundComplete == true){
                Time.timeScale = 0f;
                TutorialFinishText.SetActive(true); 
                PlayerPrefs.SetInt("PlayedTutorial",1);
                //End Tutorial Here
            }    
        }
    }

    IEnumerator StartEachTutorial(){
        PlaySoundComplete = false;

        yield return new WaitForSeconds(6);
        
        SetButtonToFalse();

        SwapToFlowerCam();

        yield return new WaitForSeconds(4.5f);

        ShowTutorialPicAndUI();
        
    }

    void ShowTutorialPicAndUI(){
        if(Flowertutorial == false){
            PickFlowers();
        }
        else if(Jumptutorial == false&&Flowertutorial==true){
            JumpingTest();
        }
        else if(Attacktutorial == false&&Jumptutorial == true){
            AttackTest();
        }
        else if(ObstacleTutorial == false&&Attacktutorial==true){
            ObstacleTest();
        }
    }

    void PickFlowers(){
        Flowertutorial = true;
        Flower.SetActive(true);
        TutorialPic1.SetActive(true);

        SetActiveTutorialTextAndTimeScale();
    }
    void JumpingTest(){
        Jumptutorial = true;
        Coin.SetActive(true);
        TutorialPic2.SetActive(true);

        SetActiveTutorialTextAndTimeScale();
        
    }
    void AttackTest(){
        Attacktutorial = true;
        Heart.SetActive(true); 
        TutorialPic3.SetActive(true); 

        SetActiveTutorialTextAndTimeScale();
    }
    void ObstacleTest(){
        ObstacleTutorial = true;
        TutorialPic4.SetActive(true); 

        SetActiveTutorialTextAndTimeScale();
    }
    void SetActiveTutorialTextAndTimeScale(){
        tutorialtext.SetActive(true);
        Time.timeScale = 0f;
    }
}
