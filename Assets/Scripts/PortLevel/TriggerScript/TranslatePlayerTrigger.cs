using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TranslatePlayerTrigger : MonoBehaviour
{

    [SerializeField] float _pointToTransform;
    [SerializeField] BoxCollider _boxCollider;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Transform playerTransform = other.GetComponent<Transform>();

            playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y, _pointToTransform);
            _boxCollider.enabled = !_boxCollider.enabled;
        }

    }
}
