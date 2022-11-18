using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioMixer _maserMixer;


    public void SetMusicOn()
    {
        _maserMixer.SetFloat("musicVolume", 0f);
    }
    public void SetMusicOff()
    {
        _maserMixer.SetFloat("musicVolume", -80f);
    }
    public void SetSoundOn()
    {
        _maserMixer.SetFloat("soundVolume", 0f);
    }
    public void SetSoundOff()
    {
        _maserMixer.SetFloat("soundVolume", -80f);
    }
}
