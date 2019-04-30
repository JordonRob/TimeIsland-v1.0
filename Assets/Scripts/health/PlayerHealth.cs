using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    Slider healthBar;

    public Rigidbody2D Player;
    public float KnockBackX;
    public float KnockBackY;
    public float maxHealth = 100;
    public float currentHealth;
    

    private Vector2 opposite;
    [HideInInspector]


    void Start()
    {
        healthBar.value = maxHealth;
        currentHealth = healthBar.value;
    }

    void TakeDamage(float Damage)
    {
        healthBar.value -= Damage;
        currentHealth = healthBar.value;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            TakeDamage(1f);
        }
         

        if(collision.gameObject.tag == "Spikes")
        {
            TakeDamage(25f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy Attack")
        {
            TakeDamage(10f);
            Player.AddForce(opposite * Time.deltaTime);
        }


        if (collision.gameObject.tag == "MiniHealthPack")
        {
            healthBar.value += 10;
            currentHealth = healthBar.value;
        }
        else if (collision.gameObject.tag == "HealthPack")
        {
            healthBar.value += 30;
            currentHealth = healthBar.value;
        }
    }

    void Update()
    {
        opposite = -Player.velocity;
    }
}
