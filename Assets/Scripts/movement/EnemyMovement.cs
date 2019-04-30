using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    Animator enemyAnimator;
    Rigidbody2D enemyBody;
    public GameObject enemyFlip;

    bool canFlip = true;
    bool facingRight = false;
    float flipTime = 2f;
    float nextFlipChance = 0f;

    public float playerDetected;
    float playerReaction;
    bool running;

    

    void Start()
    {
        enemyAnimator = GetComponentInChildren<Animator>();
        enemyBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if(Time.time > nextFlipChance)
        {
            if(Random.Range (0,10) >= 5)
            {
                Flip();
            }

            nextFlipChance = Time.time + flipTime;
        }

        //Vector2 LineCastPos = 
    }

    void Flip()
    {
        if (!canFlip)
            return;

        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;

        facingRight = !facingRight;
    }


    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Detection")
        {
            if(facingRight && col.transform.position.x < transform.position.x)
            {
                Flip();
            }
            else if(!facingRight && col.transform.position.x > transform.position.x)
            {
                Flip();
            }

            canFlip = false;
            running = true;
            playerReaction = Time.time + playerDetected;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if(col.tag == "Detection")
        {
            if(playerReaction < Time.time)
            {
                if (facingRight == false)
                {
                    enemyBody.velocity = new Vector2(-1 * enemySpeed, enemyBody.velocity.y);
                }
                else if(facingRight == true)
                {
                    enemyBody.velocity = new Vector2(1 * enemySpeed, enemyBody.velocity.y);
                }
                enemyAnimator.SetBool("enemyRun", running);
            }
        }
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "Detection")
        {
            canFlip = true;
            running = false;
            enemyBody.velocity = new Vector2(0f, 0f);
            enemyAnimator.SetBool("enemyRun", running);
        }
    }
}
