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
    [SerializeField] private GameObject _finishedModalDialoge;

    private Tween tween;

    private void Awake()
    {
        GlobalEventManager.OnCheckpointReached.AddListener(ShowCheckpointReached);
        GlobalEventManager.OnPlayerFinishedLevel.AddListener(ShowFinishedLeveDialoge);
    }

    private void ShowFinishedLeveDialoge()
    {
        _finishedModalDialoge.SetActive(true);
        _finishedModalDialoge.transform.localScale = Vector3.zero;
        _finishedModalDialoge.transform.DOScale(1, 3f);
    }

    private void ShowCheckpointReached()
    {
        _checkpointText.enabled = true;
        _checkpointText.transform.localScale = Vector3.zero;
        _checkpointText.text = "Достигнута контрольная точка!";
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
        SceneManager.LoadScene("Menu");
    }
}
