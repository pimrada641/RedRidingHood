using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class CharacterDatabase : ScriptableObject
{
    /// This Function is applied from https://www.youtube.com/watch?v=2PKBChN10us
    public CharacterList[] character; 

    public int CharacterCount{
        get{
            return character.Length;
        }
    }

    public CharacterList GetCharacter(int index){
        return character[index];
    }
    /// End
}
