using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class PlayerDataHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeLabel;
    [SerializeField] private Stopwatch stopwatch;
    private double _time = 0;
    // Подписываемся на событие GetDataEvent в OnEnable
    private void OnEnable() => YandexGame.GetDataEvent += GetData;

    // Отписываемся от события GetDataEvent в OnDisable
    private void OnDisable() => YandexGame.GetDataEvent -= GetData;

    private void Start()
    {
        if (YandexGame.SDKEnabled)
        {
            GetData();
        }

        GlobalEventManager.OnPlayerFinishedLevel.AddListener(Save);
    }

    private void Save()
    {
        YandexGame.savesData.time = stopwatch.CurrentTime;
        YandexGame.SaveProgress();
    }

    private void GetData()
    {
        if (_timeLabel != null)
        {
            _time = YandexGame.savesData.time;

            TimeSpan timeSpan = TimeSpan.FromSeconds(_time);

            _timeLabel.text = timeSpan.ToString(@"mm\:ss\:fff");
        }


    }


}
