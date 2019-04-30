using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGame : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject RaptorPrefab;
    public GameObject MiniHealthPack;
    public GameObject MegaHealthPack;
    public GameObject Reward;

    private int spawnTrigger = 3;
    private int spawnCount;
    private int raptorCount;
    private bool isItOver;
    private bool initialTrigger;

    void Awake()
    {

    }



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player" && !initialTrigger)
        {
            MiniGame();
            Debug.Log("MiniGameStart");
            initialTrigger = true;
        }

    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if (col.gameObject.tag == "Enemy")
        {
            isItOver = false;
        }
        else
            isItOver = true;

    }

    void MiniGame()
    {  
            spawn();
            Debug.Log("Triggered Spawn");

        if (isItOver == true)
        {

        }
    }

    void spawn()
    {

        raptorCount = 4;

        while (raptorCount >= 0)
        {
            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            Instantiate(RaptorPrefab, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            raptorCount--;
        }
    }


    
}
