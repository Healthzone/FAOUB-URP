using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuCameraRotate : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera _virtualCamera;
    [SerializeField] private float _speed;

    private CinemachineOrbitalTransposer cinemachineOrbital;
    

    private void Start()
    {
        cinemachineOrbital = _virtualCamera.GetCinemachineComponent<CinemachineOrbitalTransposer>();
    }
    // Update is called once per frame
    void Update()
    {
        cinemachineOrbital.m_XAxis.Value += Time.deltaTime * _speed;
    }
}
