using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveRaptors : MonoBehaviour
{
    public GameObject RaptorPrefab;

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "punch" && EnemyHealth.AliveCheck.currentHealth <= 0)
        {
            WaveGame.DeathTracker.raptorCount -= 1;
        }
    }


}
