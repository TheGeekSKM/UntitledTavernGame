using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D), typeof(Rigidbody2D))]
public class TrapBehavior : MonoBehaviour
{

    bool _draggable;
    Vector3 _dragOffset;
    Camera _cam;

    Rigidbody2D _rB;
 

    void Start()
    {
        TimeManager.Instance.AddToTraps(this);
        _rB = GetComponent<Rigidbody2D>();
        _cam = Camera.main;
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
