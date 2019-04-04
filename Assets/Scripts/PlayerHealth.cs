using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    Slider healthBar;


    public float maxHealth = 100;
    public float currentHealth;

    void Start()
    {
        healthBar.value = maxHealth;
        currentHealth = healthBar.value;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            healthBar.value -= 1f;
            currentHealth = healthBar.value;
        }
        else if(collision.gameObject.tag == "EnemyAttack")
        {
            healthBar.value -= 10f;
            currentHealth = healthBar.value;
        }

        if (collision.gameObject.tag == "MiniHealthPack")
        {
            healthBar.value += 10;
            currentHealth = healthBar.value;
        }
        else if(collision.gameObject.tag == "HealthPack")
        {
            healthBar.value += 30;
            currentHealth = healthBar.value;
        }
    }

    void Update()
    {
        
    }
}
