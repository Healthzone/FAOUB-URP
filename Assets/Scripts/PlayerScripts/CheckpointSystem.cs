using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    private Vector3 savedPosition;

    private Vector3 currentPosition;

    private GameObject playerGameObject;

    private void Awake()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }

    public void SetCheckpointPosition ()
    {
        currentPosition = playerGameObject.transform.position; 
        savedPosition = currentPosition;

        
    }

    public void UseCheckpoint()
    {
        if (savedPosition != null)
        {
            playerGameObject.transform.position = savedPosition;
        } else
        {
            Debug.Log("Cant use checkpoint");
        }    
        
    }
}
