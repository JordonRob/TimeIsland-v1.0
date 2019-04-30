using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class RaptorAttacks : MonoBehaviour
{
    private bool bitting = false;
    private Animator anim;

    private float attackDuration = 0;
    public float BiteCD;

    public Collider2D Bite;
    public Collider2D Raptor;
    private GameObject PlayerHitBox;
    private Collider2D PlayerCol;


    public float minAttackDistance = 1.5f;
    private float intialPos;

    public ColliderDistance2D ColDist;

    private void Awake()
    {
        bitting = false;
        Bite.enabled = false;
        PlayerHitBox = GameObject.Find("Player_Hitbox");
        PlayerCol = PlayerHitBox.GetComponent<BoxCollider2D>();
        anim = GetComponent<Animator>();
        anim.SetBool("bitting", bitting);
        intialPos = transform.position.x;
        minAttackDistance +=  intialPos;
;
    }

    private void FixedUpdate()
    {
        if (EnemyHealth.AliveCheck.Alive)
            ColDist = Raptor.Distance(PlayerCol);
            Debug.Log(ColDist.distance);
   
            if (!bitting && ColDist.distance < minAttackDistance)
            {
                bitting = true;
                attackDuration = BiteCD;
                Bite.enabled = true;
                anim.SetBool("bitting", bitting);
                Debug.Log("Attacked");
            }


        if (bitting)
        {
            //begins the cooldown on the punch
            if (attackDuration > 0)
            {
                attackDuration -= Time.deltaTime;
                Debug.Log("started cd");

            }
            else //resets the punch timer and hitbox
            {
                bitting = false;
                Bite.enabled = false;
                Debug.Log("collider off, idk i cant see it go off");

                anim.SetBool("bitting", bitting);
                Debug.Log("ended CD");

            }
        }
    }
}

        
