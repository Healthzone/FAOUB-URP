using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{
    public float ForceMultiply;
    public Rigidbody RB;
    public Vector3 VecSpeed;
    public LineRenderer Line;
    public Camera cam;
    public Transform cord;
    public Transform BallTransform;
    
   


   


    private void OnMouseDrag()
    {
        Line.enabled = true;
        Line.SetPosition(0, new Vector3(BallTransform.position.x, BallTransform.position.y, 0));
        cord.position = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x , Input.mousePosition.y , 0));
        Line.SetPosition(1, new Vector3(cord.position.x, cord.position.y, 0));
        VecSpeed = new Vector3(cord.position.x - BallTransform.position.x, cord.position.y - BallTransform.position.y, 0);
        
    }

    private void OnMouseUp()
    {
        Line.enabled = false;
        RB.AddForce(-VecSpeed * ForceMultiply);
        
       
    }

}
