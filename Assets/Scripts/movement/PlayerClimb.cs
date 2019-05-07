using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets._2D;

public class PlayerClimb : MonoBehaviour
{
    public Rigidbody2D PlayerRB;
    public float MaxSpeed;
    public float distance;
    public LayerMask IsThisAVine;

    private float Climable;
    private bool isClimbing;
    private RaycastHit2D hitInfo;

    private void Awake()
    {
        hitInfo = Physics2D.Raycast(transform.position, Vector2.up, distance, IsThisAVine);
    }

    void OnTriggerEnter2D(Collider2D col)
    {

        if (hitInfo != null && col.tag == "vine")
        {

            isClimbing = true;

        }

        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            isClimbing = false;
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "vine" && isClimbing == true)
        {
            Climable = Input.GetAxisRaw("Vertical");
            PlayerRB.velocity = new Vector2(PlayerRB.velocity.x, y: Climable * MaxSpeed);
            PlayerRB.gravityScale = 0f;
        }


    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.tag == "vine")
        {
            isClimbing = false;
            PlayerRB.gravityScale = 3.5f;
        }
    }
}
