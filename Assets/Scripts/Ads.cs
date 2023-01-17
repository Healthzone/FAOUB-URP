using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using YG;

public class Ads : MonoBehaviour
{
    public int CurrentUsedCheckpointNumber = 0;
    [SerializeField] private int _checkpointNumberAds = 10;

    [SerializeField] private AudioMixer _masteMixer;

    [SerializeField] private YandexGame _yg;
    



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

    private void Update()
    {
        if(_checkpointNumberAds == CurrentUsedCheckpointNumber)
        {
            _yg._FullscreenShow();
        }
    }
}
