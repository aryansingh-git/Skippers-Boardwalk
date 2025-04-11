using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTransition : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            EnableThisGame(false);
        }
    }

    private void EnableThisGame(bool enable)
    {
        ObjectThrow objectThrow = GameObject.FindGameObjectWithTag("Player").GetComponent<ObjectThrow>();
        if (objectThrow != null)
        {
            objectThrow.enabled = enable;
        }

        GameObject[] pingPongObjects = GameObject.FindGameObjectsWithTag("PingPong");
        foreach (GameObject pingPongObject in pingPongObjects)
        {
            PingPongTarget pingPongTarget = pingPongObject.GetComponent<PingPongTarget>();
            if (pingPongTarget != null)
            {
                pingPongTarget.enabled = enable;
            }

            Rigidbody rb = pingPongObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.isKinematic = !enable;
            }
        }
    }

}
