using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCVisuals : MonoBehaviour
{
    [SerializeField] List<Sprite> _spritesTex = new List<Sprite>();
    [SerializeField] SpriteRenderer _sprite;

    void Start()
    {
        _sprite.sprite = _spritesTex[Random.Range(0, _spritesTex.Count - 1)];
    }
}
