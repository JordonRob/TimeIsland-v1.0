using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggReward : MonoBehaviour
{
    public GameObject Reward;
    [HideInInspector]
    public static EggReward RewardCheck;
    public bool HasReward;

    void Awake()
    {
        HasReward = false;
        RewardCheck = this;    
    }


    void OnCollisionEnter2D(Collision2D Col)
    {
        if(Col.gameObject.tag == "Player")
        {
            HasReward = true;
            Debug.Log("HasReward True");
            Destroy(Reward);
        }
    }
}
