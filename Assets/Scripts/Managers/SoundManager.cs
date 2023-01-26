using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static YG.InfoYG;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _masterMixer;
    [SerializeField] private AudioSource _hitClip;
    [SerializeField] private AudioSource _swingClip;

    public static bool IsMusicMuted = false;

    private void Start()
    {
        GlobalEventManager.OnPlayerHitCollider.AddListener(PlayHitSound);
        GlobalEventManager.OnPlayerSwingBall.AddListener(PlaySwingSound);
    }

    private void OnApplicationFocus(bool focus)
    {
        if (!IsMusicMuted)
            MuteAllMixer(!focus);
    }

    private void OnApplicationPause(bool pause)
    {
        if (!IsMusicMuted)
            MuteAllMixer(pause);
    }


    private void PlaySwingSound()
    {
        _swingClip.Play();
    }

    private void PlayHitSound()
    {
        _hitClip.Play();
    }

    public void SetMusicOn()
    {
        IsMusicMuted = false;
        _masterMixer.SetFloat("musicVolume", 0f);
    }
    public void SetMusicOff()
    {
        IsMusicMuted = true;
        _masterMixer.SetFloat("musicVolume", -80f);
    }
    public void SetSoundOn()
    {
        _masterMixer.SetFloat("soundVolume", 0f);
    }
    public void SetSoundOff()
    {
        _masterMixer.SetFloat("soundVolume", -80f);
    }

    public void MuteAllMixer(bool silence)
    {
        if (silence)
        {
            _masterMixer.SetFloat("soundVolume", -80f);
            _masterMixer.SetFloat("musicVolume", -80f);
        }
        else
        {
            _masterMixer.SetFloat("soundVolume", 0f);
            _masterMixer.SetFloat("musicVolume", 0f);
        }

    }

}
