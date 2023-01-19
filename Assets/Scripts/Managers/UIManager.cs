using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TMP_Text _checkpointText;
    [SerializeField] private TMP_Text _bestTimeLabel;
    [SerializeField] private GameObject _finishedModalDialoge;
    [SerializeField] private GameObject _gameBtns;

    [SerializeField] private float _buttonsScaleSpeed = 1f;

    [Header("The setting buttons")]
    [SerializeField] private GameObject _musicOnBtn;
    [SerializeField] private GameObject _musicOffBtn;
    [SerializeField] private GameObject _soundOnBtn;
    [SerializeField] private GameObject _soundOffBtn;
    [SerializeField] private GameObject _pauseBtn;
    [SerializeField] private GameObject _resumeBtn;

    [Header("Canvases")]
    [SerializeField] private GameObject _controlCanvas;
    [SerializeField] private GameObject _uiCanvas;

    private bool _isSettingsOpened = false;


    private void Awake()
    {
        GlobalEventManager.OnCheckpointReached.AddListener(ShowCheckpointReached);
        GlobalEventManager.OnPlayerFinishedLevel.AddListener(ShowFinishedLeveDialoge);
    }

    private void ShowFinishedLeveDialoge()
    {
        _controlCanvas.SetActive(false);
        _uiCanvas.SetActive(false);
        _finishedModalDialoge.SetActive(true);
        _finishedModalDialoge.transform.localScale = Vector3.zero;
        _finishedModalDialoge.transform.DOScale(1, 3f);

    }

    private void ShowCheckpointReached()
    {
        _checkpointText.enabled = true;
        _checkpointText.transform.localScale = Vector3.zero;
        _checkpointText.text = "Достигнута контрольная точка";
        DOTween.Sequence()
            .Append(_checkpointText.transform.DOScale(1, 1))
            .AppendInterval(4f)
            .Append(_checkpointText.transform.DOScale(0, 1))
            .AppendCallback(ResetCheckpointText);
    }

    private void ResetCheckpointText()
    {
        _checkpointText.enabled = false;
        _checkpointText.transform.localScale = Vector3.one;
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene("PirateBay");
    }
    public void ToMainMenu()
    {
        DOTween.KillAll();
        SceneManager.LoadScene("Menu");
    }

    public void ShowBestTimeLabel(double time)
    {
        TimeSpan timeSpan = TimeSpan.FromSeconds(time);
        _bestTimeLabel.text = $"Ваш рекорд: {timeSpan.ToString(@"mm\:ss\:fff")}";
    }

    public void SettingsInteractBtn()
    {
        if (!_isSettingsOpened)
        {
            _isSettingsOpened = true;
            _gameBtns.transform.localScale = Vector3.zero;
            _gameBtns.SetActive(true);
            DOTween.Sequence()
                .SetEase(Ease.Linear)
                .Append(_gameBtns.transform.DOScale(1, _buttonsScaleSpeed));

        } else if(_isSettingsOpened )
        {
            _isSettingsOpened = false;
            _gameBtns.transform.localScale = Vector3.one;
            DOTween.Sequence()
            .SetEase(Ease.OutExpo)
            //.Append(_gameBtns.transform.DOScale(1.1f, _buttonsScaleSpeed - 0.7f))
            .Append(_gameBtns.transform.DOScale(0f, _buttonsScaleSpeed));
        }
    }

    public void SetMusicGameObjectOn()
    {
        _musicOffBtn.SetActive(false);
        _musicOnBtn.SetActive(true);
    }
    public void SetMusicGameObjectOff()
    {
        _musicOnBtn.SetActive(false);
        _musicOffBtn.SetActive(true);
    }
    public void SetSoundGameObjectOn()
    {
        _soundOffBtn.SetActive(false);
        _soundOnBtn.SetActive(true);
    }
    public void SetSoundGameObjectOff()
    {
        _soundOnBtn.SetActive(false);
        _soundOffBtn.SetActive(true);
    }
    public void SetPauseGameObjectOn()
    {
        _resumeBtn.SetActive(false);
        _pauseBtn.SetActive(true);
    }
    public void SetResumeGameObjectOn()
    {
        _pauseBtn.SetActive(false);
        _resumeBtn.SetActive(true);
    }
}
