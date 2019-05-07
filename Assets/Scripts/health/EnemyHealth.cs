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

    private bool Flashing;
    public float flashingLength;
    private float flashCounter;

    public SpriteRenderer EnemySprite;
    private Animator RaptorAnimator;
    

    void Awake()
    {
        AliveCheck = this;
        Flashing = false;
        RaptorAnimator = GetComponentInParent<Animator>();
        RaptorAnimator.SetBool("Dead", Alive);

    }

    void Update()
    {

        if (Flashing)
        {
            if (flashCounter > flashingLength * .66f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 0f);
                Debug.Log("You are now invisible");

            }
            else if (flashCounter > flashingLength * .33f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 1f);

            }
            else if (flashCounter > 0f)
            {
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 0f);

            }
            else
            {
                //returns the players full alpha value so you can see the player character when it stops flashing
                EnemySprite.color = new Color(EnemySprite.color.r, EnemySprite.color.g, EnemySprite.color.b, 1f);
                Flashing = false;
            }

            flashCounter -= Time.deltaTime;


            if (currentHealth <= 0)
            {
                Alive = false;
                RaptorAnimator.SetBool("Dead", Alive);
                Destroy(transform.parent.gameObject, 0.4f);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // removes 5 health from enemies upon collision with players punch
        if (collision.gameObject.tag == "punch")
        {
            Debug.Log("hit");
            maxHealth -= 5f;
            currentHealth = maxHealth;
            Flashing = true;
            flashCounter = flashingLength;
        }

    }
 
}
