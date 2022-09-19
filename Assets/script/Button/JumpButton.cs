using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpButton : MonoBehaviour
{
    public static int JumpCount = 0;
    AudioSource jumpSound;

    public void Start(){
        jumpSound = GetComponent<AudioSource>();
    }

    public void JumpClick(){
        if(CharacterAnimation.isGamestart){

            if(CharacterAnimation.isGrounded){
                jumpSound.Play();
                CharacterAnimation.isGrounded = false; CharacterAnimation.playerAnimation.SetTrigger("Jump");
                CharacterAnimation.rigidbodycharacter.AddForce(new Vector2(0f,CharacterData.jumpForce), ForceMode2D.Impulse);
                JumpCount++;
            }
            
            else if(JumpCount < CharacterData.MaxJump){
                jumpSound.Play();
                CharacterAnimation.rigidbodycharacter.velocity = new Vector2(CharacterAnimation.rigidbodycharacter.velocity.x,0); //เซ็ตให้แรงกระโดดกลับมาเป็น 0 ก่อน
                CharacterAnimation.rigidbodycharacter.AddForce(new Vector2(0f,CharacterData.jumpForce), ForceMode2D.Impulse);
                JumpCount++;
            }
        }
    }

}
