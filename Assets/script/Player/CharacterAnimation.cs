using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterAnimation : MonoBehaviour
{
    public static bool isGamestart;
    public static bool isGrounded;

    public static Rigidbody2D rigidbodycharacter;
    public static Animator playerAnimation;

    void Start()
    {
        Time.timeScale = 1f;
        isGamestart = false;
        playerAnimation = GetComponent<Animator>();
        rigidbodycharacter = GetComponent<Rigidbody2D>();   

        StartCoroutine(CooldownBeforeStart());
    }

    IEnumerator CooldownBeforeStart(){
        yield return new WaitForSeconds(5);
        isGamestart = true; 
        playerAnimation.SetTrigger("Start");
    }

    void Update()
    {
        playerAnimation.SetBool("Grounded",isGrounded);
    }

    private void OnCollisionEnter2D(Collision2D collision){
        JumpButton.JumpCount = 0;
        isGrounded = true;
    }
}
