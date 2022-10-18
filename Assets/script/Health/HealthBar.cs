using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject gameoverscreen;
    private Image health_Bar;
    public float currentHealth;
    private float MaxHealth = 100f;
    void Start()
    {
        health_Bar = GetComponent<Image>();
    }

    void Update()
    {
        if(this.gameObject.CompareTag("Enemy"))
        {
            BloodCount(EnemyScript.currentHP);
        }
        if(this.gameObject.CompareTag("Player"))
        {
            BloodCount(ChraracterScript.HP);
            if(currentHealth == 0)
            {
              ShowGameOver();
            }
        }
    }

    void BloodCount(float currentHP)
    {
        if(this.gameObject.CompareTag("Enemy")){
            currentHealth = EnemyScript.currentHP;
            health_Bar.fillAmount = currentHealth/MaxHealth;
        }
        if(this.gameObject.CompareTag("Player")){
            currentHealth = ChraracterScript.HP;
            health_Bar.fillAmount = currentHealth/MaxHealth;
            if(currentHealth == 0){
                gameoverscreen.SetActive(true);
                health_Bar.fillAmount = 0;
                Time.timeScale = 0f;
            }
        }
    }
}

