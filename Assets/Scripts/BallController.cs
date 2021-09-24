using UnityEngine;
using System.Collections;

public class BallController : MonoBehaviour
{

    [SerializeField] private float forceMultiplier;
    [SerializeField] private float lineRenderDistance = 3;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 vectorSpeed;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform lineTransform;
    [SerializeField] private Transform ballTransform;

    [SerializeField] private FixedJoystick fixedJoystick;





    private void Awake()
    {
        fixedJoystick = GameObject.FindGameObjectWithTag("Player").GetComponent<FixedJoystick>();
    }

    private void Update()
    {
        if (fixedJoystick.IsUsedJoystick)
        {
            SetPlayerMovement();
        }
        else
        {
            lineRenderer.enabled = false;
            rb.AddForce(-vectorSpeed * forceMultiplier);
            vectorSpeed = Vector3.zero;
            lineRenderer.SetPosition(0, Vector3.zero);
            lineRenderer.SetPosition(1, Vector3.zero);
        }
    }


    private void SetPlayerMovement()
    {
        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, ballTransform.position);



        Vector3 lineSift = new Vector3(fixedJoystick.Direction.x * lineRenderDistance, fixedJoystick.Direction.y * lineRenderDistance, 0) + ballTransform.position;

        lineRenderer.SetPosition(1, lineSift);



        // lineTransform.position = mainCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0));
        //Vector3 direction = new Vector3(fixedJoystick.Horizontal, fixedJoystick.Vertical, ballTransform.position.z);
        //Debug.Log(direction);
        //lineTransform.localPosition = dialingSpeedFactor * direction;
        //lineRenderer.SetPosition(1, new Vector3(lineTransform.localPosition.x, lineTransform.localPosition.y, lineTransform.localPosition.z));
        vectorSpeed = new Vector3(lineSift.x - ballTransform.localPosition.x, lineSift.y - ballTransform.localPosition.y, 0);

        Debug.Log(lineSift);
    }

}
