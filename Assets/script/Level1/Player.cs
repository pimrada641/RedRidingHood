using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    /// This Function is applied from https://www.youtube.com/watch?v=2PKBChN10us
    public CharacterDatabase characterDB;
    public SpriteRenderer artworkSprite;

    private int selectedOption = 0;

    void Start(){
        Load();

        UpdateCharacter(selectedOption);
    }

    private void UpdateCharacter(int selectedOption){
        CharacterList character = characterDB.GetCharacter(selectedOption);
        artworkSprite.sprite = character.characterSprite;
    }

    private void Load(){
        selectedOption = PlayerPrefs.GetInt("selectedOption",0);
    }
    /// End
}
