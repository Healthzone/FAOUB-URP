using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.UI;

public class SpriteAtlass : MonoBehaviour
{
    [SerializeField] private SpriteAtlas _spriteAtlas;
    [SerializeField] private string _spriteAtlasName;

    [ExecuteInEditMode]
    void Start()
    {
        GetComponent<Image>().sprite = _spriteAtlas.GetSprite(_spriteAtlasName);
    }
}
