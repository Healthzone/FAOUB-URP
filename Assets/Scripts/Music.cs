using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Music : MonoBehaviour
{
    [SerializeField] private AudioClip[] _musics;
    [SerializeField] private AudioSource _audioSource;
    private int currentClipIndex = 0;

    private void Start()
    {
        _audioSource.clip = _musics[currentClipIndex];
        _audioSource.Play();
    }

    void Update()
    {
        //Debug.Log(_audioSource.time);
        if (!_audioSource.isPlaying && _audioSource.time == 0)
        {
            _audioSource.clip = GetNextClip();
            _audioSource.Play();
        }
    }

    private AudioClip GetNextClip()
    {
        if (currentClipIndex >= _musics.Length - 1)
        {
            currentClipIndex = 0;
        }
        else
        {
            currentClipIndex += 1;
        }
        return _musics[currentClipIndex];
    }
}
