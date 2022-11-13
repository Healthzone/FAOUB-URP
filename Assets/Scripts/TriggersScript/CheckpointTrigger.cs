using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GlobalEventManager.SendCheckpointReached();
            gameObject.GetComponent<Collider>().enabled = false;
        }
    }
}
