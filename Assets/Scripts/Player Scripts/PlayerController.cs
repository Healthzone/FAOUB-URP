using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;

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

    [SerializeField] private FloatingJoystick joystick;

    [SerializeField] private float forcePowerBorder = 5f;
    [SerializeField] private float forcePowerDelta = 0.02f;

    [SerializeField] private TextMeshProUGUI powerText;

    [SerializeField] private Image joystickImage;
    [SerializeField] private Image[] joystickImageHandler;



    private float forcePower = 1f;

    private void Awake()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FloatingJoystick>();
        //joystickImage = joystick.gameObject.GetComponent<Image>();
        //joystickImageHandler = joystick.gameObject.GetComponentsInChildren<Image>();
    }


    private void FixedUpdate()
    {


        if (joystick.IsUsedJoystick && (joystick.IsEnableToUse == true))
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

            joystick.IsEnableToUse = false;
            //SetFixedJoystickAlphaColor(60);


        }
    }

    private void OnCollisionStay()
    {
        joystick.IsEnableToUse = true;
        //SetFixedJoystickAlphaColor(255);

    }
    private void SetPlayerMovement()
    {

        lineRenderer.enabled = true;
        lineRenderer.SetPosition(0, ballTransform.position);

        Vector3 lineSift = new Vector3(joystick.Direction.x * lineRenderDistance, joystick.Direction.y * lineRenderDistance, 0) + ballTransform.position;
        lineRenderer.SetPosition(1, lineSift);
        vectorSpeed = new Vector3(lineSift.x - ballTransform.localPosition.x, lineSift.y - ballTransform.localPosition.y, 0);


        if ((Mathf.Abs(joystick.Direction.x) + Mathf.Abs(joystick.Direction.y)) >= 1.0f)
        {

            forcePower += forcePowerDelta * Time.deltaTime;

            clampPower = Mathf.Clamp(forcePower, 1f, forcePowerBorder);

            powerText.text = "Power: " + string.Format("{0:f2}", clampPower);

        }



    }

    private void SetFixedJoystickAlphaColor(byte alphaValue)
    {
        joystickImage.color = new Color32(255, 255, 255, alphaValue);
        joystickImageHandler[1].color = new Color32(255, 255, 255, alphaValue);
    }

}
