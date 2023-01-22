using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField]
    private int _frameRange = 60;


    private int[] _frameBuffer;
    private int _frameBufferIndex;


    public int AverageFPS { get; private set; }
    public int HighestFPS { get; private set; }
    public int LowestFPS { get; private set; }

    private void Update()
    {
        if (_frameBuffer == null || _frameRange != _frameBuffer.Length)
        {
            InitializeBuffer();
        }

        UpadeBuffer();
        CalculateFPS();

        
    }

    private void InitializeBuffer()
    {
        if (_frameRange<= 0)
        {
            _frameRange = 1;
        }
        _frameBuffer = new int[_frameRange];
        _frameBufferIndex = 0;
    }

    private void UpadeBuffer()
    {
        _frameBuffer[_frameBufferIndex++] = (int)(1f / Time.unscaledDeltaTime);
        if (_frameBufferIndex >= _frameRange)
        {
            _frameBufferIndex = 0;
        }
    }

    private void CalculateFPS()
    {
        int sum = 0;
        int lowest = int.MaxValue;
        int highest = 0;

        for (int i = 0; i < _frameRange; i++)
        {
            int fps = _frameBuffer[i];
            sum += fps;
            if (fps > highest)
            {
                highest = fps;

            }
            if (fps < lowest)
            {
                lowest = fps;
            }
        }

        HighestFPS = highest;
        LowestFPS = lowest;
        AverageFPS = sum / _frameRange;
    }

   

   



}
