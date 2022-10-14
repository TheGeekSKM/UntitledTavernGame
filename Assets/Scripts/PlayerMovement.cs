using System.Runtime.Serialization;
using System.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private Rigidbody2D _rb;
    [SerializeField] private WeaponController _weapon;
    [SerializeField, ReadOnly] bool _isMoving;
    public bool IsMoving => _isMoving;



    public float MoveSpeed 
    {
        get { return _moveSpeed; }
        set { _moveSpeed = value; }
    }

    private Vector2 _moveDirection;
    private Vector2 _mousePosition;


   

    
    void Update()
    {
        Cursor.visible = true;
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        if (Input.GetMouseButtonDown(0) && !SaiUtils.IsMouseOverUi)
        {
            _weapon.Fire();
        }
        _moveDirection = new Vector2(moveX, moveY).normalized;
        _mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //Transform
        // Vector2 direction = _mousePosition - _rb.position;
        // float angle = Vector2.SignedAngle(Vector2.right, direction);
        // transform.eulerAngles = new Vector3 (0, 0, angle);

        if (_moveDirection.magnitude > 0.01f)
        {
            _isMoving = true;
        }
        else
        {
            _isMoving = false;
        }

    }

  

    private void FixedUpdate()
    {
        // _rb.velocity = new Vector2(_moveDirection.x * _moveSpeed, _moveDirection.y * _moveSpeed );
        _rb.MovePosition(new Vector2((transform.position.x + _moveDirection.x * _moveSpeed * Time.deltaTime),
            transform.position.y + _moveDirection.y * _moveSpeed * Time.deltaTime));

        
        
        Vector2 aimDirection = _mousePosition - _rb.position;
        float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        _rb.rotation = aimAngle;
        
       
    }
}
