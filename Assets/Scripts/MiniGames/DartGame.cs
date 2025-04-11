using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEngine.GraphicsBuffer;

public class DartGame : MiniGame
{
    [SerializeField]
    private Balloon[] targets;

    protected override void StartGame()
    {
        base.StartGame();

        player.GetComponent<ObjectThrow>().enabled = true;


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
            player.GetComponent<ObjectThrow>().ResetThrowCountText(); // Reset the throw count text when all targets are destroyed
            EndGame();
        }
    }

    public override void EndGame()
    {
       
        player.GetComponent<ObjectThrow>().enabled = false;

        for (int i = 0; i < targets.Length; i++)
        {
            targets[i].gameObject.SetActive(true);

        }
        base.EndGame();
    }
}
