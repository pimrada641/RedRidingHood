using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Audio;

public class DialogScript : MonoBehaviour
{
    public Animator anim;
    public Animator talking;
    public Animator dialogueBox;

    public GameObject SpeakerPhoto,SpeakerPhotoNext;
    public GameObject Speakername1,Speakername2;
    public GameObject Scene1,Scene2;

    public AudioMixerSnapshot werewolfcome;
    public AudioSource punchsound;
    public AudioSource doorknockdown;

    public GameObject DialogueBox;

    public GameObject Canvas;

    public GameObject Fade;
    public static bool fade;
    public GameObject darkscreen;

    public GameObject VideoBG;
    
    public TextMeshProUGUI textComponent;

    public string[] lines;
    public float textSpeed;
    private int index;

    private bool Talking;

    void Start()
    {
        Talking = false;
        fade = false;
        Fade.SetActive(false);
        SpeakerPhotoNext.SetActive(false);
        Speakername2.SetActive(false);
        textComponent.text = string.Empty;
        StartDialogue();
    }
    void Update(){
        CheckDialogue();
        if(Input.GetMouseButtonDown(0)){
            if(textComponent.text == lines[index]){
                NextLine();
            }
            else{
                StopAllCoroutines();
                Talking = false;
                textComponent.text = lines[index];
            }
            
        }
        talking.SetBool("Talking",Talking);
    }
    void StartDialogue(){
        index = 0;
        StartCoroutine(TypeLine());
    }

    void momtalk(){
        SpeakerPhoto.SetActive(true);
        SpeakerPhotoNext.SetActive(false);
        Speakername2.SetActive(false);
        Speakername1.SetActive(true);
    }

    void werewolftalk(){
        SpeakerPhoto.SetActive(false);
        SpeakerPhotoNext.SetActive(true);
        Speakername2.SetActive(true);
        Speakername1.SetActive(false);
    }

    void CheckDialogue(){
        if (index == 3){
            darkscreen.SetActive(true);
            VideoBG.SetActive(false);
        }
        else if (index >= 5 && index <= 9 || index >= 21){
            darkscreen.SetActive(false);
            werewolfcome.TransitionTo(0.1f);
            Scene1.SetActive(true);
        }
        else if (index >= 10 && index <= 12){
            Scene1.SetActive(false);
            Scene2.SetActive(true);
        }
        else if (index > 12 && index < 21){
            Scene1.SetActive(false);
            darkscreen.SetActive(true);
        }

        if (index == 6 || index == 7 || index == 9 || index == 21 || index == 11){
            werewolftalk();
        }
        else{
            momtalk();
        }
    }

    IEnumerator TypeLine(){
        if(index == 3 || index == 8 || index == 9 || index == 10|| index == 11 || index == 12){
            if(index!=3){
                Speakername1.SetActive(false);
                punchsound.Play();
            }
            else{
                doorknockdown.Play();
            }
            if(index == 12){
                punchsound.Play();
                punchsound.Play();
                punchsound.Play();
            }
            dialogueBox.SetTrigger("Shake");
        }
            foreach (char c in lines[index].ToCharArray()){
            textComponent.text += c;
            if(textComponent.text.Length == lines[index].Length){
                Talking = false;
            }
            else if(textComponent.text.Length < lines[index].Length){
                if(index != 3){
                    Talking = true;
                }
            }
            yield return new WaitForSeconds(textSpeed);
        }
        
    }
    void NextLine(){
        StopAllCoroutines();
        if(index < lines.Length - 1){
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else{
            textComponent.gameObject.SetActive(false);
            fade = true;     

        }
    }
}
