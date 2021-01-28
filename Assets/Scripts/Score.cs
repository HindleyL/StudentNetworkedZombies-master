using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using Mirror;

public class Score : NetworkBehaviour
{
    Text scoreTxt;
    [SyncVar(hook = nameof(Setscore))]
    public int scoreValue = 5;


    public override void OnStartServer()
    {
        base.OnStartServer();
        Setscore(scoreValue);
    }
    void Setscore(int newscore)
    {
        string healthStr = "";
        for (int i = 1; i <= newscore; i++)
        {
            healthStr += "-";
        }
        scoreTxt.text = healthStr;
        if (newscore <= 0)
        {
            scoreTxt.text = "Lose";
            if (isLocalPlayer)
            {
                GetComponent<Tank>().enabled = false;
            }
        }
    }
    void OnTriggerEnter(Collider collision)
    {
        if (isLocalPlayer && collision.gameObject.tag == "Bullet")
        {
            Debug.Log("hit " + gameObject);
            scoreValue = scoreValue + 1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
