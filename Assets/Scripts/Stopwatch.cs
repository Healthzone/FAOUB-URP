using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private bool isActive = true;
    [SerializeField] private float _currentTime;
    private TMP_Text _stopwatchLabel;


    public bool IsActive { get => isActive; set => isActive = value; }
    public float CurrentTime { get => _currentTime; private set => _currentTime = value; }

    void Start()
    {
        _stopwatchLabel = gameObject.GetComponent<TMP_Text>();
        CurrentTime = 0f;
    }

    void Update()
    {
        if (IsActive)
        {
            CurrentTime += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(CurrentTime);
            _stopwatchLabel.text = time.ToString(@"mm\:ss\:fff");
        }

    }
}
