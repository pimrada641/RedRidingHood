using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAnimator : MonoBehaviour
{
    public CharacterDatabase characterDB;
    Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        int usedcharacter = PlayerPrefs.GetInt("selectedOption",0);
        Debug.Log(usedcharacter);
        anim = GetComponent<Animator>();

        anim.runtimeAnimatorController = Resources.Load(characterDB.GetCharacter(usedcharacter).characterName) as RuntimeAnimatorController;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
