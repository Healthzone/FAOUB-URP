using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointSystem : MonoBehaviour
{
    private Vector3 savedPosition;

    private GameObject playerGameObject;

    [SerializeField] private Ads ads;

    private void Awake()
    {
        playerGameObject = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
        SetCheckpointPosition();
    }

    public void SetCheckpointPosition ()
    {
        savedPosition = playerGameObject.transform.position; 
    }

    public void UseCheckpoint()
    {
        if (savedPosition != null)
        {
            playerGameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, 0, 0); 
            playerGameObject.transform.position = savedPosition;

            ads.CurrentUsedCheckpointNumber++;
        } else
        {
            Debug.Log("Cant use checkpoint");
        }    
        
    }
}
