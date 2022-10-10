using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;



public class DialogueEvent : MonoBehaviour
{
    [SerializeField, ReadOnly] int _lineIndex;
    [SerializeField] DialoguePlayer _player;
    [SerializeField] int _desiredIndex;
    [SerializeField] UnityEvent _desiredEvent;
    bool _onlyOnce = false;

    void Start()
    {
        _lineIndex = _player._lineIndex;
    }

    void Update()
    {
        _lineIndex = _player._lineIndex;

        if (_lineIndex == _desiredIndex && !_onlyOnce)
        {
            _desiredEvent?.Invoke();
            _onlyOnce = true;
        }
    }

   
}
