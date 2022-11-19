using StylizedWater;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GraphicSettings : MonoBehaviour
{
    [SerializeField] private GameObject _mainCamera;
    public static bool IsReflectionOn = false;

    public void SetReflection()
    {
        IsReflectionOn = !IsReflectionOn;
        Debug.Log("Reflection is: " + IsReflectionOn);
    }

    private void Awake()
    {
        Debug.Log("Reflection is: " + IsReflectionOn);
        _mainCamera.GetComponent<PlanarReflections>().enabled = IsReflectionOn;
    }
}
