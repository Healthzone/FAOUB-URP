using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Audio;

public class SoundVisibility : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void registerVisibilityChangeEvent();


    [SerializeField] private AudioMixer audioMixer;
#if UNITY_WEBGL && !UNITY_EDITOR
    void Start()
    {
        registerVisibilityChangeEvent();
    }

    void OnVisibilityChange(string visibilityState)
    {
        // System.Console.WriteLine(visibilityState);
        if (!SoundManager.IsMusicMuted)
        {
            if (visibilityState != "visible")
            {
                audioMixer.SetFloat("soundVolume", -80f);
                audioMixer.SetFloat("musicVolume", -80f);
                //Debug.Log("Mixer muted");
            }
            else if (visibilityState == "visible")
            {
                audioMixer.SetFloat("soundVolume", 0f);
                audioMixer.SetFloat("musicVolume", 0f);
                //Debug.Log("Mixer unmuted");
            }
        }

    }
#endif
}
