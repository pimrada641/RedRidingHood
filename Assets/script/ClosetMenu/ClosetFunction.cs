using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ClosetFunction : MonoBehaviour
{
    public CharacterDatabase characterDB;

    public SkinItemDatabase SkinitemDB;

    public static bool unlockskin;

    public TMP_Text nameText;
    public TMP_Text descriptionText;
    public SpriteRenderer artworkSprite;
    public Animator animation;

    public TMP_Text itemamount;
    string item_amount; 
    public GameObject itemsprite;

    public static int selectedOption;

    void Start(){
        animation = GetComponent<Animator>();
        
        Load();

        UpdateCharacter(selectedOption);
    }

    void Update(){
        animation.SetInteger("SkinNumber",selectedOption);
        animation.SetBool("Unlockskin",unlockskin);
    }

    public void NextOption(){
        selectedOption++;

        if(selectedOption >= characterDB.CharacterCount){
            selectedOption = 0;
        }
        UpdateCharacter(selectedOption);
    }

    public void BackOption(){
        selectedOption--;

        if(selectedOption <0 ){
            selectedOption = characterDB.CharacterCount-1;
        }
        UpdateCharacter(selectedOption);
    }

    void UpdateCharacter(int selectedOption){
        ShowCharacterFromDatabase();
        if(selectedOption >= 1){
            ShowSkinItemFromDatabase();
        }
    }

    void ShowCharacterFromDatabase(){
        CharacterList character = characterDB.GetCharacter(selectedOption);
        unlockskin = character.unlockcharacter;
        artworkSprite.sprite = character.characterSprite;
        nameText.text = character.characterName;
        descriptionText.text = character.characterDescription;
    }

    void ShowSkinItemFromDatabase(){
        SkinItemList skinitem = SkinitemDB.GetSkin(selectedOption-1);
        itemsprite.GetComponent<Image>().sprite = skinitem.itemsprite; 
        item_amount = skinitem.amount.ToString();
        itemamount.text = item_amount;
    }

    private void Load(){
        selectedOption = PlayerPrefs.GetInt("selectedOption",0);
    }

    public void Save(){
        PlayerPrefs.SetInt("selectedOption",selectedOption);
    }

    void ChangeScene(int sceneID){
        SceneManager.LoadScene(sceneID);
    }
}
