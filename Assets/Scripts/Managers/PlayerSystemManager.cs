using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSystemManager : MonoBehaviour
{
    [SerializeField] private GameObject _playerObject;
    [SerializeField] private CheckpointSystem _checkpointSystem;
    [SerializeField] private Stopwatch _stopwatch;
    [SerializeField] private PlayerController _playerController;
    [SerializeField] private List<Vector3> _spawnPoints;
    [SerializeField] private int _spawnIndex;

    private void Start()
    {
        GlobalEventManager.OnCheckpointReached.AddListener(CheckpointReached);
        GlobalEventManager.OnPlayerFinishedLevel.AddListener(FinishLevel);
        InitPlayer();
    }

    private void FinishLevel()
    {
        _stopwatch.IsActive = false;
    }

    private void CheckpointReached()
    {
        _checkpointSystem.SetCheckpointPosition();
    }

    private void InitPlayer()
    {
        _playerController.gameObject.transform.position = _spawnPoints[_spawnIndex];
    }
}
