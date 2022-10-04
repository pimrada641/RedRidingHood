using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public GameObject gameoverscreen;
    private Image health_Bar;
    public float currentHealth;
    public float MaxHealth = 100f;
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
        currentHealth = currentHP;
        health_Bar.fillAmount = currentHealth/MaxHealth;
        return;
    }

    void ShowGameOver()
    {
        gameoverscreen.SetActive(true);
        health_Bar.fillAmount = 0;
        Time.timeScale = 0f;
    }
}

