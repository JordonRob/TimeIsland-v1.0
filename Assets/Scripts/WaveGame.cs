using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveGame : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject RaptorPrefab;
    public GameObject Reward;
    public static WaveGame DeathTracker;
    [HideInInspector]
    public int raptorCount;


    private int spawnCount;
    private bool isItOver;
    private bool initialTrigger;

    void Awake()
    {
        initialTrigger = false;
        isItOver = false;
        raptorCount = 4;
        DeathTracker = this;
    }

    void FixedUpdate()
    {
        if(raptorCount <= 0 && !isItOver)
        {
            isItOver = true;
            reward();
        }
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

    void MiniGame()
    {  
            spawn();
            Debug.Log("Triggered Spawn");

    }

    void spawn()
    {

        spawnCount = 3;

        while (spawnCount >= 0)
        {

            Instantiate(RaptorPrefab, spawnPoints[spawnCount].position, spawnPoints[spawnCount].rotation);
            spawnCount--;
        }
    }

    void reward()
    {
        if(isItOver == true)
        {
            Debug.Log("Spawn Reward");
            Instantiate(Reward);
        }
    }
    
}
