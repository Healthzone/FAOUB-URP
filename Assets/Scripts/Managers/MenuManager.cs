using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _reflectionToogleGO;
    private Toggle.ToggleEvent emptyToggleEvent = new Toggle.ToggleEvent();
    public void StartGame()
    {
        SceneManager.LoadScene("PirateBay");
    }
    private void Awake()
    {
        Toggle reflectionToggle = _reflectionToogleGO.GetComponent<Toggle>();
        var originalEvent = reflectionToggle.onValueChanged;
        reflectionToggle.onValueChanged = emptyToggleEvent;
        reflectionToggle.isOn = GraphicSettings.IsReflectionOn;
        reflectionToggle.onValueChanged = originalEvent;
    }
}
