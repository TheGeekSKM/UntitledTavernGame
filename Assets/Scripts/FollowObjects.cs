using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowObjects : MonoBehaviour
{
    [Header("Targets and Speed")]
   [SerializeField] private List<Transform> _targets = new List<Transform>();
   [SerializeField] private float _followSpeed = 5f;


    [Header("References")]
   [SerializeField] private Rigidbody2D _rB;

   [SerializeField, ReadOnly] private Transform _currentTarget;
   
   private void Update()
   {
        if (_targets.Count > 0) { _currentTarget = SaiUtils.GetClosestTransform(_targets, transform); }
   }

   private void FixedUpdate()
   {
        if (_rB != null)
        {
            Vector2 _movePosition = transform.position;
            _movePosition.x = Mathf.MoveTowards(transform.position.x, _currentTarget.position.x, _followSpeed * Time.deltaTime);
            _movePosition.y = Mathf.MoveTowards(transform.position.y, _currentTarget.position.y, _followSpeed * Time.deltaTime);

            _rB.MovePosition(_movePosition);
        }
   }

   

}
