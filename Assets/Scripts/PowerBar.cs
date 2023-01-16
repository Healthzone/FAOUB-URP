using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerBar : MonoBehaviour
{
    public float fill;
    [SerializeField] private Image _bar;

    void Start()
    {
        fill = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
        _bar.fillAmount = fill;
    }
}
