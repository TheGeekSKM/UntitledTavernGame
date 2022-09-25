using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TrackingDate : MonoBehaviour
{
    [SerializeField] IntegerReference _numberOfDays;
    [SerializeField] TextMeshProUGUI _text;

    void OnValidate()
    {
        if (_text == null) {_text = GetComponent<TextMeshProUGUI>();}
    }

    void Update()
    {
        _text.text = $"Day #{_numberOfDays.Value}";
    }
}
