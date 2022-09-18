using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyScript : MonoBehaviour//, IUnityAdsLoadListener, IUnityAdsShowListener
{
    private int currentLevel;
    public int MaxHP = 100;
    public static int currentHP;
    //public GameObject Flower;

    bool isattacking=false;

    public Animator EnemyAnim;
    public AudioSource AttackSound;

    public void Start()
    {
        currentHP = MaxHP;
    }
    private void Update(){
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.CompareTag("Player")){
            if(this.gameObject.CompareTag("Enemy")){
                EnemyAnim.SetTrigger("Attack");
            }            
            AttackSound.Play();
            ChraracterScript.HP-=20f;
        }
    }

    public void TakeDamageFunction(){
        currentHP -= ChraracterScript.AttackDamage;
        this.transform.parent.position = new Vector2(Mathf.Lerp(transform.parent.position.x,transform.parent.position.x+7,1f),transform.parent.position.y);
        if(currentHP <= 0){
            Debug.Log("die");
            StartCoroutine(die());
        }
    }
    IEnumerator die(){
        Pickup.PointCount += 2000;
        this.gameObject.SetActive(false);
        yield return new WaitForSeconds(2);
        Tutorial.TutorialComplete = true;
    }
}