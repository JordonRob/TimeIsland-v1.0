using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public Collider2D PortalCollider;
    public GameObject RaptorPrefab;
    public Transform[] EnemySpawns;
    private int raptorCount = 0;


    void Awake()
    {
        spawnEnemies();

    }

    void spawnEnemies()
    {
        while (raptorCount < EnemySpawns.Length)
        {
            Instantiate(RaptorPrefab, EnemySpawns[raptorCount].position, EnemySpawns[raptorCount].rotation);
            raptorCount++;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && EggReward.RewardCheck.HasReward == true)
        {
            Debug.Log("YouWin");
            WinGame();
        }
    }

    void WinGame()
    {
        
    }

    void restart()
    {
        if(PlayerHealth.DeadCheck.PlayerDead && Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        }
    }
}
