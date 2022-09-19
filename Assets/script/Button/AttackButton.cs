using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackButton : MonoBehaviour
{
    public PlayerAttackPoint playerAttackPoint;
    public static AudioSource attackSound;
    public void Start(){
        attackSound = GetComponent<AudioSource>();
    }

    public void AttackClick(){
        if(CharacterAnimation.isGamestart){
            CharacterAnimation.playerAnimation.SetTrigger("Attack");
        }
        playerAttackPoint.AttackEnemyInArea();
    }
}
