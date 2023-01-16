using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrajectoryRenderer : MonoBehaviour
{
    private LineRenderer _lineRendereComponent;
    void Start()
    {
        _lineRendereComponent= GetComponent<LineRenderer>();
    }

    public void ShowTrajectory(Vector3 origin, Vector3 speed, Vector3 gravity)
    {
        Vector3[] points = new Vector3[10];
        _lineRendereComponent.positionCount = points.Length;

        for (int i = 0; i < points.Length; i++)
        {
            float time = i * 0.1f;
            points[i] = origin + speed * time + gravity * time * time / 2f; 
        }

        _lineRendereComponent.SetPositions(points);
    }
}
