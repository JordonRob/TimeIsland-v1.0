using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class GameConroller : MonoBehaviour
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
            WinGame();
        }
    }

    void WinGame()
    {
        
    }

}
