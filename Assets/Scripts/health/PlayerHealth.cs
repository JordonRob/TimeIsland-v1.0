using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityStandardAssets._2D;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    Slider healthBar;

    public static PlayerHealth DeadCheck;

    public GameObject PlayerObj;
    public Rigidbody2D Player;
    public float KnockBackX;
    public float KnockBackY;
    public float maxHealth = 100;
    public float currentHealth;
    private int dieOnce = 0;

    private bool Flashing;
    public float flashingLength;
    private float flashCounter;

    public Animator DeathScreen;
    public SpriteRenderer PlayerSprite;
    public Transform DeathScreenFollow;
    public GameObject DeathScreenObj;
    



    private Vector2 opposite;
    [HideInInspector]
    public bool PlayerDead;

    void Awake()
    {
        healthBar.value = maxHealth;
        currentHealth = healthBar.value;
        Flashing = false;
        PlayerDead = false;
        DeadCheck = this;
        DeathScreen.SetBool("GameOver", PlayerDead);
    }

    void Update()
    {
        opposite = -Player.velocity;



        if (Flashing)
        {
            if (flashCounter > flashingLength * .66f)
            {
                PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 0f);
                //Debug.Log("You are now invisible");

            }
            else if (flashCounter > flashingLength * .33f)
            {
                PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 1f);

            }
            else if (flashCounter > 0f)
            {
                PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 0f);

            }
            else
            {
                //returns the players full alpha value so you can see the player character when it stops flashing
                PlayerSprite.color = new Color(PlayerSprite.color.r, PlayerSprite.color.g, PlayerSprite.color.b, 1f);
                Flashing = false;
            }

            flashCounter -= Time.deltaTime;
        }

        playerDead();
    }

    void TakeDamage(float Damage)
    {
        healthBar.value -= Damage;
        currentHealth = healthBar.value;
        Flashing = true;
        flashCounter = flashingLength;
        playerDead();
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

    void playerDead()
    {
        if(currentHealth <= 0f)
        {
            if (dieOnce < 2)
            {
                PlayerDead = true;
                Instantiate(DeathScreenObj);
                Camera2DFollow.SwitchFollow.target = DeathScreenFollow;
                Camera2DFollow.SwitchFollow.cameraSize = Camera.main.orthographicSize += 160f;
                DeathScreen.SetBool("GameOver", PlayerDead);
                dieOnce++;
            }
            restart();


        }
    }

    void restart()
    {
        if (PlayerHealth.DeadCheck.PlayerDead && Input.GetKeyDown(KeyCode.R))
        {
            dieOnce = 0;
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}
