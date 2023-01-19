using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class Tip : MonoBehaviour
{
    [SerializeField] private float _tipDelay;
    [SerializeField] private Image _setCheckpointImage;
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        StartCoroutine(ShowTip());
    }


    IEnumerator ShowTip()
    {
        yield return new WaitForSeconds(_tipDelay);

        gameObject.SetActive(true);

        DOTween.Sequence()
            .Append(_setCheckpointImage.DOFade(0, 0.5f))
            .Append(_setCheckpointImage.DOFade(1, 0.5f))
            .Append(_setCheckpointImage.DOFade(0, 0.5f))
            .Append(_setCheckpointImage.DOFade(1, 0.5f))
            .Append(_setCheckpointImage.DOFade(0, 0.5f))
            .Append(_setCheckpointImage.DOFade(1, 0.5f))
            .Append(_setCheckpointImage.DOFade(0, 0.5f))
            .Append(_setCheckpointImage.DOFade(1, 0.5f))
            .Append(_setCheckpointImage.DOFade(0, 0.5f))
            .Append(_setCheckpointImage.DOFade(1, 0.5f))
            .Append(_setCheckpointImage.DOFade(0, 0.5f))
            .Append(_setCheckpointImage.DOFade(1, 0.5f))
            .Append(_setCheckpointImage.DOFade(0, 0.5f))
            .Append(_setCheckpointImage.DOFade(1, 0.5f))
            .Append(_setCheckpointImage.DOFade(0, 0.5f))
            .Append(_setCheckpointImage.DOFade(1, 0.5f));


        DOTween.Sequence()
            .Append(rectTransform.DOAnchorPos(Vector2.zero, 1f))
            .AppendInterval(7f)
            .Append(rectTransform.DOAnchorPos(new Vector2(0, 500), 1f));
    }
}
