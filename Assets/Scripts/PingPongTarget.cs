using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PingPongTarget : Target
{
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private Transform endPoint;

    protected float currentMoveTime;

    [SerializeField]
    protected float moveTime;

    private bool isMovingToEnd = true;

    protected virtual void UpdateTime()
    {
        if (isMovingToEnd)

        {
            currentMoveTime += Time.deltaTime;
            if (currentMoveTime > moveTime)
            {
                isMovingToEnd = false;
            }

        }
        else
        {
            currentMoveTime -= Time.deltaTime;
            if (currentMoveTime < 0)
            {
                isMovingToEnd = true;
            }
        }
    }



    // Update is called once per frame
    void Update()
    {
        UpdateTime();

        transform.position = Vector3.Lerp(startPoint.position, endPoint.position, currentMoveTime / moveTime);
    }

}