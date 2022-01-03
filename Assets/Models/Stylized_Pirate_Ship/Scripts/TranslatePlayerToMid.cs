using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslatePlayerToMid : MonoBehaviour
{

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            Transform playerTransform = other.GetComponent<Transform>();

            playerTransform.position = new Vector3 (playerTransform.position.x, playerTransform.position.y, -1.06f);
        }

    }

    

}
