// using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MouseActions : MonoBehaviour
{
    [SerializeField, HighlightIfNull] GameObject _image;
    [SerializeField] UnityEvent _onClickEvent;
    private bool _clicked = false;

    void Start()
    {
        _image.SetActive(false);
        _clicked = false;
    }
    void OnMouseEnter()
    {
        if (_image != null && !_clicked) {_image.gameObject.SetActive(true);}
    }
    void OnMouseOver()
    {
        if (!_clicked) {_image.transform.position = Input.mousePosition;}
    }

    void OnMouseExit()
    {
        _image.gameObject.SetActive(false);   
    }

    void OnMouseDown()
    {
        _image.gameObject.SetActive(false);
        _clicked = true;
        _onClickEvent?.Invoke();
    }
}
