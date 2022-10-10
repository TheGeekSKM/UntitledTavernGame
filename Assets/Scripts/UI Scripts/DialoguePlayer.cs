using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialoguePlayer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _textComponent;
    [SerializeField] List<string> _lines;
    [SerializeField] float _textSpeed;
    [SerializeField, ReadOnly] public int _dialogueIndex;

    [SerializeField, ReadOnly] public int _lineIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        _textComponent.text = "";
        _lineIndex = 0;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (_textComponent.text == _lines[_dialogueIndex])
            {
                NextLine();
                _lineIndex++;
            }
            else
            {
                StopAllCoroutines();
                _textComponent.text = _lines[_dialogueIndex];
            }
        }

        // Debug.Log(_dialogueIndex);
        // Debug.Log(_lineIndex);
    }

    public void StartDialogue()
    {
        _dialogueIndex = 0;
        StartCoroutine(TypeLine());
    }

    void NextLine()
    {
        if (_dialogueIndex < _lines.Count - 1)
        {
            _dialogueIndex++;
            _textComponent.text = "";
            StartCoroutine(TypeLine());
        }
        else
        {
            SaiUtils.SwitchNextScene();
            gameObject.SetActive(false);
        }
    }

    IEnumerator TypeLine()
    {
        foreach (char c in _lines[_dialogueIndex].ToCharArray())
        {
            _textComponent.text += c;
            yield return new WaitForSeconds(_textSpeed);
        }
    }
}
