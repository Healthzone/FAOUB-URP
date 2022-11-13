using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatapultTrigger : MonoBehaviour
{
    private Animation animation;
    private void Start()
    {
        animation = gameObject.GetComponent<Animation>();
    }
    private void OnCollisionStay(Collision collision)
    {
        Debug.Log("Player has touched the catapult");
        if (collision.gameObject.tag == "Player" && !animation.isPlaying)
        {
            animation.Play();
        }
    }

}
