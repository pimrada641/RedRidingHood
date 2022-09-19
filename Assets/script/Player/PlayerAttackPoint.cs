using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackPoint : MonoBehaviour
{
    public GameObject enemy;
    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;

    public void AttackEnemyInArea(){
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position,attackRange,enemyLayers);

        foreach(Collider2D enemy in hitEnemies){
            AttackButton.attackSound.Play();
            enemy.GetComponent<EnemyScript>().TakeDamageFunction();
        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint == null){
            return;
        }
        Gizmos.DrawWireSphere(attackPoint.position,attackRange);
    }

}