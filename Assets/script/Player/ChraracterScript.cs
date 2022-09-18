using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class ChraracterScript : MonoBehaviour
{
    public float jumpForce = 100f;
    public float speed = 10f;
    public static bool gamestarted = false;

    //------Jump Setting------
    int JumpCount=0;
    int MaxJump = 2;

    public static float HP = 100f;

    bool grounded = false;
    static public int AttackDamage = 20;

    public GameObject Enemy;
    Rigidbody2D rigidbodycharacter;
    Animator anim;
    AudioSource AudioSource;
    public AudioSource AttackSound; //เพิ่มเสียง

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;

    void Start()
    {
        Time.timeScale = 1f;
        gamestarted = false;
        anim = GetComponent<Animator>();
        rigidbodycharacter = GetComponent<Rigidbody2D>();   
        AudioSource = GetComponent<AudioSource>(); //ให้ audiosource มาจากไฟล์เสียงใน component ผู้เล่น

        StartCoroutine(CooldownBeforeStart());
        
    }

    IEnumerator CooldownBeforeStart(){
        yield return new WaitForSeconds(5);
        gamestarted = true; 
    }

    void Update()
    {
        anim.SetBool("Grounded",grounded);
        
    }

    public void JumpButton(){
        //Debug.Log("Jump");
        if(gamestarted == true){
            if(grounded == true){
                AudioSource.Play();
                grounded = false; anim.SetTrigger("Jump");
                rigidbodycharacter.AddForce(new Vector2(0f,jumpForce));
                JumpCount++;
            }
            else if(JumpCount < MaxJump){
                rigidbodycharacter.velocity = new Vector2(rigidbodycharacter.velocity.x,0); //เซ็ตให้แรงกระโดดกลับมาเป็น 0 ก่อน
                rigidbodycharacter.AddForce(new Vector2(0f,jumpForce));
                AudioSource.Play();
                JumpCount++;
            }
        }
    }
    public void AttackButton(){
        //Debug.Log("Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            AttackSound.Play();
            Enemy.GetComponent<EnemyScript>().TakeDamageFunction();
        }

        if((gamestarted == true)){
            anim.SetTrigger("Attack");
            
        }

    }
    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }
    private void OnCollisionEnter2D(Collision2D collision){
        JumpCount = 0;
        grounded = true;
    }
    private void FixedUpdate(){
        if(gamestarted == true){
            anim.SetTrigger("Start");
          //  rigidbodycharacter.velocity = new Vector2(speed,rigidbodycharacter.velocity.y);
        }
        //if(jump == true){
        //    rigidbodycharacter.AddForce(new Vector2(0f,jumpForce)); jump = false;
        //}
    }
}
