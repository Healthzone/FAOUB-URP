using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Stopwatch : MonoBehaviour
{
    [SerializeField] private bool isActive = true;
    private TMP_Text _stopwatchLabel;
    private float _currentTime;

    public bool IsActive { get => isActive; set => isActive = value; }

    void Start()
    {
        _stopwatchLabel = gameObject.GetComponent<TMP_Text>();
        _currentTime = 0f;
    }

    void Update()
    {
        if (IsActive)
        {
            _currentTime += Time.deltaTime;
            TimeSpan time = TimeSpan.FromSeconds(_currentTime);
            _stopwatchLabel.text = time.ToString(@"mm\:ss\:fff");
        }

    }
}
