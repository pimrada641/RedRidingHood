using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClosetButton : MonoBehaviour
{
    public SkinItemDatabase SkinitemDB;
    public CharacterDatabase characterDB;
    public Button usablebutton;
    public TMP_Text usablebutt_text;
    private ColorBlock lockbuttoncolor , usablebuttoncolor;
    public Button lockbutton;
    int selectop;
    private int usedcharacter;

    void Start(){
        lockbuttoncolor = lockbutton.GetComponent<Button>().colors;
        usablebuttoncolor = usablebutton.GetComponent<Button>().colors;
    }
    void Update(){
        selectop = ClosetFunction.selectedOption;
        usedcharacter = PlayerPrefs.GetInt("selectedOption",0);

        CharacterList character = characterDB.GetCharacter(selectop);

        if(selectop == usedcharacter){
            ChangeButtonToUsedButton();
        }
        else{
            ChangeToUsableButton();
        }
        
        CheckButtonUsableOrNot();
        

        if(selectop>=1){
            if(SkinitemDB.skinItem[selectop-1].amount == 5){
                ChangeButtonToInteractable();
            }
            else{
                lockbutton.interactable = false;
            }
        }
    }

    void CheckButtonUsableOrNot(){
        CharacterList character = characterDB.GetCharacter(selectop);
        if(character.unlockcharacter == true){
            usablebutton.gameObject.SetActive(true);
            lockbutton.gameObject.SetActive(false);
        }
        else{
            usablebutton.gameObject.SetActive(false);
            lockbutton.gameObject.SetActive(true);
        }
    }

    void ChangeButtonToInteractable(){ //เปลี่ยนสีเมื่อเก็บ Item ได้ครบ และเปิด Active
        lockbutton.interactable = true;
        lockbuttoncolor.normalColor = new Color32(33,51,132,230);
        lockbuttoncolor.pressedColor = new Color32(33,51,132,230);
        lockbuttoncolor.highlightedColor = new Color32(33,51,132,190);
        lockbuttoncolor.selectedColor = new Color32(33,51,132,230);
        lockbutton.colors = lockbuttoncolor;
    }
    public void Unlockskin(){ //Unlock Skin
        CharacterList character = characterDB.GetCharacter(selectop);
        character.unlockcharacter = true;
        ClosetFunction.unlockskin = true;
    }
    void ChangeToUsableButton(){ //ปุ่มสามารถใช้งานได้Skin
        usablebutton.interactable = true;
        usablebuttoncolor.normalColor = Color.red;
        usablebutt_text.text = "Use";
    }
    void ChangeButtonToUsedButton(){
        usablebutton.interactable = false;
        usablebuttoncolor.normalColor = Color.white;
        usablebutt_text.text = "Used";
    }

    public void AddcardP(){
        SkinitemDB.skinItem[0].amount++;
    }
}
