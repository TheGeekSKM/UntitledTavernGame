using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryReference : MonoBehaviour
{
    [SerializeField, HighlightIfNull] Inventory _inventory;
    [SerializeField] TextMeshProUGUI _text;

    public int NumberOfBones 
    {
        get
        {
            return _inventory._numOfBones;
        }
        set
        {
            _inventory._numOfBones = value;
        }
    }

    void Update()
    {
        if (_text != null)
        {
            _text.text = $"Bones: {_inventory._numOfBones}";
        }
    }
}
