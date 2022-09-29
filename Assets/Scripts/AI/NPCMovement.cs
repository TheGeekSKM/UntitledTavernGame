using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class NPCMovement : MonoBehaviour
{
    [SerializeField] float _moveSpeed;
    [SerializeField] Rigidbody2D _rB;
    [SerializeField, ReadOnly] bool _isWalking;
    [SerializeField] float _walkTime;
    [SerializeField] float _waitTime;
    [SerializeField, ReadOnly] float _walkCounter;
    [SerializeField, ReadOnly] float _waitCounter;

    [SerializeField, ReadOnly] int _directionNumber;

    void OnValidate()
    {
        if (_rB == null) {_rB = GetComponent<Rigidbody2D>();}
    }
    void Start()
    {
        _waitCounter = _waitTime;
        _walkCounter = _walkTime;

        ChooseDirection();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (_isWalking)
        {
            _walkCounter -= Time.deltaTime;
            switch (_directionNumber)
            {
                case 0:
                    _rB.velocity = new Vector2(0, _moveSpeed);
                    break;
                case 1:
                    _rB.velocity = new Vector2(_moveSpeed, 0);
                    break;
                case 2:
                    _rB.velocity = new Vector2(0, -_moveSpeed);
                    break;
                case 3:
                    _rB.velocity = new Vector2(-_moveSpeed, 0);
                    break;
            }
            if (_walkCounter < 0)
            {
                StopWalking();
            }
        }
        else
        {
            _waitCounter -= Time.deltaTime;
            _rB.velocity = Vector2.zero;
            
            if (_waitCounter < 0)
            {
                ChooseDirection();
            }
        }
    }

    void ChooseDirection()
    {
        _directionNumber = Random.Range(0, 4);
        _isWalking = true;
        _walkCounter = _walkTime;
    }
    void StopWalking()
    {
        _isWalking = false;
        _waitCounter = _waitTime;
    }
}
