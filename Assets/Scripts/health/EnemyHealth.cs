using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 10;
    public float currentHealth;
    [HideInInspector]
    public bool Alive = true;

    public static EnemyHealth AliveCheck;

    void Awake()
    {
        AliveCheck = this;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // removes 5 health from enemies upon collision with players punch
        if (collision.gameObject.tag == "punch")
        {
            Debug.Log("hit");
            maxHealth -= 5f;
            currentHealth = maxHealth;

        }

        if (currentHealth <= 0)
        {
            Alive = false;
            Destroy(transform.parent.gameObject);
        }
    }
 
}
