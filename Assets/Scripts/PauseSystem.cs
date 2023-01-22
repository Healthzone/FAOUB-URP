using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    [SerializeField] private Stopwatch _timer;
    public void PauseGame()
    {
        Time.timeScale = 0f;
        _timer.IsActive= false;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
        _timer.IsActive= true;
    }
}
