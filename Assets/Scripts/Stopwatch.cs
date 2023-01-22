using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private bool isActive = true;
    [SerializeField] private double _currentTime = 0;
    private TMP_Text _stopwatchLabel;


    public bool IsActive { get => isActive; set => isActive = value; }
    public double CurrentTime { get => _currentTime;}

    void Start()
    {
        _stopwatchLabel = gameObject.GetComponent<TMP_Text>();
    }

    void Update()
    {
        if (IsActive)
        {
            _currentTime += Time.unscaledDeltaTime;
            TimeSpan time = TimeSpan.FromSeconds(_currentTime);
            _stopwatchLabel.text = time.ToString(@"mm\:ss\:fff");
        }

    }
}
