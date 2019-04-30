using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacks : MonoBehaviour
{
    private bool punching = false;
    private bool shooting = false;
    private Animator anim;

    private float attackTimer = 0;
    public float attackCD = 0.5f;

    public Collider2D punch;

    private void Awake()
    {
        punching = false;
        shooting = false;
        punch.enabled = false;
        anim = GetComponent<Animator>();
        anim.SetBool("punch", punching);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.V) && !punching)
        {
            punching = true;
            attackTimer = attackCD;
            punch.enabled = true;
            anim.SetBool("punch", punching);

        }

        if(punching)
        {
            //begins the cooldown on the punch
            if(attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;
            }
            else  //resets the punch timer and hitbox
            {
                punching = false;
                punch.enabled = false;
                anim.SetBool("punch", punching);

            }
        }
    }
}
