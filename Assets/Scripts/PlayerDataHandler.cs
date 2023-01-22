using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using YG;

public class PlayerDataHandler : MonoBehaviour
{
    [SerializeField] private TMP_Text _timeLabel;
    [SerializeField] private Stopwatch _stopwatch;
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private LeaderboardYG _leaderboard;
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
        Debug.Log("SDK enabled: " + YandexGame.SDKEnabled);
        if (YandexGame.SDKEnabled)
        {
            Debug.Log("Best time: " + YandexGame.savesData.time);
            if (_stopwatch.CurrentTime < YandexGame.savesData.time || YandexGame.savesData.time == 0)
            {
                YandexGame.savesData.time = _stopwatch.CurrentTime;
                YandexGame.SaveProgress();
                _leaderboard.NewScoreTimeConvert(Convert.ToSingle(_stopwatch.CurrentTime));


            }
            _leaderboard.UpdateLB();
            _uiManager.ShowBestTimeLabel(YandexGame.savesData.time);
            _uiManager.ShowCurrentTimeLabel(_stopwatch.CurrentTime);
        }

    }

    public void ResetSaveData()
    {
        YandexGame.savesData.time = 0;
        YandexGame.SaveProgress();
        Debug.Log("Saved data reset successfully");
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
