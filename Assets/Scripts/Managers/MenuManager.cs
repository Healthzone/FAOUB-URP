using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _reflectionToogleGO;
    [SerializeField] private GameObject _LeaderBoardGO;
    [SerializeField] private GameObject _MenuGO;
    public void StartGame()
    {
        SceneTransition.SwitchToScene("PirateBay");
    }

    public void OpenLeaderBoard()
    {
        _LeaderBoardGO.SetActive(true);
        _MenuGO.SetActive(false);
    }
    public void CloseLeaderBoard()
    {
        _LeaderBoardGO.SetActive(false);
        _MenuGO.SetActive(true);
    }
}
