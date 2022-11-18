using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaxScore : MonoBehaviour
{
    [SerializeField] private Stopwatch stopwatch;
    private UIManager uiManager;
    private float _bestTime;
    private void Start()
    {
        GlobalEventManager.OnPlayerFinishedLevel.AddListener(GetMaxScore);
        _bestTime = 0;

       uiManager = GetComponent<UIManager>();

    }

    private void GetMaxScore()
    {
        _bestTime = PlayerPrefs.GetFloat("PirateBayBestTime", -1);
        Debug.Log("CurrentTime: " + stopwatch.CurrentTime);
        Debug.Log("BestTime: " + _bestTime);
        if (stopwatch.CurrentTime > _bestTime)
        {
            PlayerPrefs.SetFloat("PirateBayBestTime", stopwatch.CurrentTime);
            uiManager.ShowBestTimeLabel(stopwatch.CurrentTime);
            return;
        }
        uiManager.ShowBestTimeLabel(_bestTime);

    }
}
