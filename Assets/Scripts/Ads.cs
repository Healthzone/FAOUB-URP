using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using YG;

public class Ads : MonoBehaviour
{

    [SerializeField] private AudioMixer _masteMixer;

    [SerializeField] private YandexGame _yg;
    
    private void Start()
    {
        GlobalEventManager.OnPlayerFinishedLevel.AddListener(ShowFullscreenAd);
    }

    private void ShowFullscreenAd()
    {
        YandexGame.FullscreenShow();
    }

    public void OpenAds()
    {
        _masteMixer.SetFloat("musicVolume", -80f);
    }
    public void RewardVideo()
    {
        GlobalEventManager.SendCheckpointReached();
    }

    public void CloseAds()
    {
        _masteMixer.SetFloat("musicVolume", 0f);
    }

}
