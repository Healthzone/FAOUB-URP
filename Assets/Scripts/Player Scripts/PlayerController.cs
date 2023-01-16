using UnityEngine;
using System.Collections;
using TMPro;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour
{

    public float clampPower = 1f;

    [SerializeField] private float forceMultiplier;
    [SerializeField] private float lineRenderDistance = 3;
    [SerializeField] private Rigidbody rb;
    [SerializeField] private Vector3 vectorSpeed;
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Camera mainCamera;
    [SerializeField] private Transform ballTransform;

    [SerializeField] private FloatingJoystick joystick;

    [SerializeField] private float forcePowerBorder = 5f;
    [SerializeField] private float forcePowerDelta = 0.02f;

    [SerializeField] private Image joystickImage;
    [SerializeField] private Image[] joystickImageHandler;

    [SerializeField] private TrajectoryRenderer trajectoryRenderer;
    [SerializeField] private LineRenderer trajectoryLine;
    [SerializeField] private PowerBar powerBar;


    private Vector3 _gravity;
    private bool isStarted = false;



    private float forcePower = 1f;

    private void Awake()
    {
        GlobalEventManager.OnPlayerClosedTutorial.AddListener(TutorialClosed);
    }

    private void TutorialClosed()
    {
        joystick = GameObject.FindGameObjectWithTag("Joystick").GetComponent<FloatingJoystick>();
        isStarted = true;
    }

    private void Start()
    {
        _gravity = GetComponent<CustomGravity>().gravity;
    }

    private void FixedUpdate()
    {

        if (isStarted)
        {
            if (joystick.IsUsedJoystick && (joystick.IsEnableToUse == true))
            {
                SetPlayerMovement();
            }
            else
            {
                Vector3 speed = -vectorSpeed * forceMultiplier * clampPower;
                lineRenderer.enabled = false;
                trajectoryLine.enabled = false;
                powerBar.fill = 0.05f;
                rb.AddForce(speed, ForceMode.VelocityChange);


                clampPower = 1f;
                forcePower = 1f;

                vectorSpeed = Vector3.zero;
                lineRenderer.SetPosition(0, Vector3.zero);
                lineRenderer.SetPosition(1, Vector3.zero);

                joystick.IsEnableToUse = false;
                //SetFixedJoystickAlphaColor(60);
            }
        }
    }

    private void OnCollisionStay()
    {
        if (isStarted)
        {
            joystick.IsEnableToUse = true;
        }
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

            powerBar.fill = clampPower / 4f;

        }
        trajectoryLine.enabled = true;
        trajectoryRenderer.ShowTrajectory(transform.position, -vectorSpeed * clampPower * forceMultiplier, _gravity);


    }

    private void SetFixedJoystickAlphaColor(byte alphaValue)
    {
        joystickImage.color = new Color32(255, 255, 255, alphaValue);
        joystickImageHandler[1].color = new Color32(255, 255, 255, alphaValue);
    }

}
