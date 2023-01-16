using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private GameObject _tutorialCanvas;
    [SerializeField] private GameObject _gameCanvases;
    [SerializeField] private GameObject _player;
    public void CloseTutorial()
    {
        _tutorialCanvas.SetActive(false);
        _gameCanvases.SetActive(true);
        GlobalEventManager.SendPlayerClosesTutorial();
    }
}
