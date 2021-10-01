using UnityEngine;
using System.Collections;
using TMPro;

public class PlayerController : MonoBehaviour
{

    public float clampPower = 1f;

    [SerializeField] private float forceMultiplier;
    [SerializeField] private float lineRenderDistance = 3;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 vectorSpeed;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform lineTransform;
    [SerializeField] private Transform ballTransform;

    [SerializeField] private FixedJoystick fixedJoystick;

    [SerializeField] private float forcePowerBorder = 5f;
    [SerializeField] private float forcePowerDelta = 0.02f;

    [SerializeField] private TextMeshProUGUI powerText;


    private float forcePower = 1f;

    private void Awake()
    {
        fixedJoystick = GameObject.FindGameObjectWithTag("FixedJoystick").GetComponent<FixedJoystick>();
    }

    private void FixedUpdate()
    {


        if (fixedJoystick.IsUsedJoystick)
        {
            SetPlayerMovement();

        }
        else
        {
            lineRenderer.enabled = false;
            rb.AddForce(-vectorSpeed * forceMultiplier * clampPower);
            clampPower = 1f;
            forcePower = 1f;
            vectorSpeed = Vector3.zero;
            powerText.text = "Power: " + clampPower;
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
        vectorSpeed = new Vector3(lineSift.x - ballTransform.localPosition.x, lineSift.y - ballTransform.localPosition.y, 0);

        if ((Mathf.Abs(fixedJoystick.Direction.x) + Mathf.Abs(fixedJoystick.Direction.y)) >= 1.0f)
        {
            
            forcePower += forcePowerDelta * Time.deltaTime;

            clampPower =  Mathf.Clamp(forcePower, 1f, forcePowerBorder);

            powerText.text = "Power: " + string.Format("{0:f2}", clampPower);
           
        }


        
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Y))
        {
            gameObject.GetComponent<Transform>().position = new Vector3(gameObject.transform.localPosition.x, gameObject.transform.localPosition.y, -1.06f);
        }
    }
}
