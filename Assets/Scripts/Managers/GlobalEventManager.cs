using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.Events;

public class GlobalEventManager : MonoBehaviour
{
    public static UnityEvent OnCheckpointReached = new UnityEvent();
    public static UnityEvent OnPlayerFinishedLevel = new UnityEvent();
    public static UnityEvent OnPlayerClosedTutorial = new UnityEvent();



    public static void SendCheckpointReached()
    {
        Debug.Log("Checkpoint reached!");
        OnCheckpointReached.Invoke();
    }

    public static void SendPlayerFinishedLevel()
    {
        Debug.Log("Player finished level!");
        OnPlayerFinishedLevel.Invoke();
    }

    public static void SendPlayerClosesTutorial()
    {
        OnPlayerClosedTutorial.Invoke();
    }
}
