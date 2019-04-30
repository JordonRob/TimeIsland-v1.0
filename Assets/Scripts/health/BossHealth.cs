using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public float maxHealth = 200;
    public float currentHealth;

    private void OnTriggerStay2D(Collider2D collision)
    {
        // removes 5 health from enemies upon collision with players punch
        if (collision.gameObject.name == "punch")
        {
            maxHealth -= 5f;
            currentHealth = maxHealth;

        }

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }
}
