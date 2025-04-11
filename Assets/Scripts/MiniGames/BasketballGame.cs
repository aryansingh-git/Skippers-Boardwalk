using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class BasketballGame : MiniGame
{
    protected override void StartGame()
    {
        base.StartGame();

        player.GetComponent<ObjectThrow>().enabled = true;
        
    }

    public override void EndGame()
    {
        
        player.GetComponent<ObjectThrow>().enabled = false;
        base.EndGame();
    }

}
