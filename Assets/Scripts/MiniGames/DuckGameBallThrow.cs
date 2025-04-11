using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DuckGameBallThrow : MiniGame
{

    [SerializeField]
    private PingPongTarget[] targets;
   
   
    protected override void StartGame()
    {
        base.StartGame();

        player.GetComponent<ObjectThrow>().enabled = true;

        for(int i = 0; i < targets.Length; i++)
        {
            targets[i].enabled = true;
        }
    }

    protected override void Update()
    {
        base.Update();

        bool allTargetsDestroyed = true;
        for (int i = 0; i < targets.Length; i++)
        {
            if (targets[i].gameObject.activeSelf == true)
            {
                allTargetsDestroyed = false;
            }
        }

        if (allTargetsDestroyed)
        {
            player.GetComponent<ObjectThrow>().ResetThrowCountText();
            EndGame();
        }
    }

    public override void EndGame()
    {


        player.GetComponent<ObjectThrow>().enabled = false;
        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].enabled = false;
            targets[i].gameObject.SetActive(true);
        }
        base.EndGame();
    }

}
