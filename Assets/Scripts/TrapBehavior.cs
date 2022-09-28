using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class TrapBehavior : MonoBehaviour
{

    bool _draggable;
    Vector3 _dragOffset;
    Camera _cam;

    [SerializeField] Rigidbody2D _rB;
    [SerializeField] SpriteRenderer _sprite;
    Sprite _originalSprite;
    [SerializeField, HighlightIfNull] Sprite _selectedSprite;
 
    void OnValidate()
    {
        if (_rB == null) {_rB = GetComponent<Rigidbody2D>();}
        if (_sprite == null) {_sprite = GetComponentInChildren<SpriteRenderer>();}
    }

    void Start()
    {
        TimeManager.Instance.AddToTraps(this);
        _cam = Camera.main;
        _originalSprite = _sprite.sprite;
        
    }

    void Update()
    {
        if (TimeManager.Instance._currentTime == TIME.DAY) {_draggable = true;}
        else {_draggable = false;}
    }

    void OnMouseDown()
    {
        if (_draggable)
        {
            _dragOffset = transform.position - GetMousePosition();
            Debug.Log("Clicked on Trap");
        }
    }

    void OnMouseDrag()
    {
        if (_draggable)
        {
            _rB.MovePosition(GetMousePosition() + _dragOffset);
        }
    }

    void OnMouseOver()
    {
        if (_draggable) {_sprite.sprite = _selectedSprite;}
    }

    void OnMouseExit()
    {
        _sprite.sprite = _originalSprite;    
    }

    Vector3 GetMousePosition()
    {
        var mousePos = _cam.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        return mousePos;
    }

    [SerializeField] int _damageAmount = 3;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            DoTrap(other.gameObject.GetComponent<Health>());
        }
    }

    public void DoTrap(Health _trappedHealth)
    {
        _trappedHealth.CurrentHealth -= _damageAmount;
        Destroy(gameObject);
    }
}
