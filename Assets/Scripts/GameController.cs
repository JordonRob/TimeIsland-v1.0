using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets._2D;

public class GameController : MonoBehaviour
{
    public Collider2D PortalCollider;
    public GameObject RaptorPrefab;
    public Transform[] EnemySpawns;
    public GameObject WinScreenObj;
    private int raptorCount = 0;
    private bool WinScreenBool;
    public Transform WinScreenFollow;

    public Animator WinScreenAnim;
    private float WinOnce = 0;


    void Awake()
    {
        spawnEnemies();
        WinScreenBool = false;
    }

    void spawnEnemies()
    {
        while (raptorCount < EnemySpawns.Length)
        {
            Instantiate(RaptorPrefab, EnemySpawns[raptorCount].position, EnemySpawns[raptorCount].rotation);
            raptorCount++;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player" && EggReward.RewardCheck.HasReward == true)
        {
            Debug.Log("YouWin");
            WinScreenBool = true;
            WinGame();
        }
    }

    void WinGame()
    {
        if (WinOnce < 2)
        {
            Instantiate(WinScreenObj);
            Camera2DFollow.SwitchFollow.target = WinScreenFollow;
            Camera2DFollow.SwitchFollow.cameraSize = Camera.main.orthographicSize += 160f;
            WinScreenAnim.SetBool("WinGame", WinScreenBool);
            WinOnce++;
        }
    }
}

