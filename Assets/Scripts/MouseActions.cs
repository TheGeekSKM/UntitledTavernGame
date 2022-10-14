// using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class MouseActions : MonoBehaviour
{
    [SerializeField, HighlightIfNull] GameObject _image;
    [SerializeField] UnityEvent _onClickEvent;
    [SerializeField] UnityEvent _onEnterEvent;


    void Start()
    {
        _image.SetActive(false);

    }
    void OnMouseEnter()
    {
        if (_image != null) {_image.gameObject.SetActive(true);}
        _onEnterEvent?.Invoke();
    }
    void OnMouseOver()
    {
        _image.transform.position = Input.mousePosition;
    }

    void OnMouseExit()
    {
        _image.gameObject.SetActive(false);   
    }

    void OnMouseDown()
    {
        _image.gameObject.SetActive(false);

        _onClickEvent?.Invoke();
    }
}
