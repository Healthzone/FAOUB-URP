using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystemManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private CheckpointSystem _checkpointSystem;
    [SerializeField] private Stopwatch _stopwatch;

    private void Start()
    {
        GlobalEventManager.OnCheckpointReached.AddListener(CheckpointReached);
        GlobalEventManager.OnPlayerFinishedLevel.AddListener(FinishLevel);
    }

    private void FinishLevel()
    {
        _stopwatch.IsActive = false;
    }

    private void CheckpointReached()
    {
        _checkpointSystem.SetCheckpointPosition();
    }
}
